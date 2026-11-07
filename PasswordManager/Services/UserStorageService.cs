using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using PasswordManager.Models;

namespace PasswordManager.Services
{
    public class UserStorageService
    {
        private readonly CryptoService _crypto = new();

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true
        };

        public string FilePath { get; }

        public bool StorageExists => File.Exists(FilePath);

        public UserStorageService()
        {
            string projectDirectory =
                FindProjectDirectory() ?? AppContext.BaseDirectory;

            string dataDirectory = Path.Combine(
                projectDirectory,
                "Data");

            Directory.CreateDirectory(dataDirectory);

            FilePath = Path.Combine(dataDirectory, "users.dat");
        }

        private static string? FindProjectDirectory()
        {
            DirectoryInfo? directory =
                new DirectoryInfo(AppContext.BaseDirectory);

            while (directory != null)
            {
                // В корне проекта должен находиться файл .csproj.
                if (directory.GetFiles("*.csproj").Length > 0)
                {
                    return directory.FullName;
                }

                directory = directory.Parent;
            }

            // Если файл проекта не найден, используем каталог приложения.
            return null;
        }

        // Создаёт исходное хранилище только с учётной записью ADMIN.
        public void CreateInitialStorage(string passPhrase)
        {
            if (StorageExists)
            {
                throw new InvalidOperationException(
                    "Хранилище уже существует.");
            }

            List<User> users = new()
            {
                new User
                {
                    Username = "ADMIN",
                    PasswordHash = "",
                    IsBlocked = false,
                    PasswordRestrictionsEnabled = false,
                    MinPasswordLength = 0,
                    PasswordExpirationMonths = 0,
                    PasswordChangedAt = null
                }
            };

            SaveUsers(users, passPhrase);
        }

        // Загружает файл, расшифровывает его и получает пользователей.
        public List<User> LoadUsers(string passPhrase)
        {
            if (!StorageExists)
            {
                throw new FileNotFoundException(
                    "Файл учётных записей не найден.", FilePath);
            }

            byte[] encryptedData = File.ReadAllBytes(FilePath);
            byte[] plaintext = _crypto.Decrypt(
                encryptedData, passPhrase);

            try
            {
                UserDatabase? database;

                try
                {
                    database = JsonSerializer.Deserialize<UserDatabase>(
                        plaintext, _jsonOptions);
                }
                catch (JsonException ex)
                {
                    throw new CryptographicException(
                        "Неверная парольная фраза или файл повреждён.",
                        ex);
                }

                if (database?.Users == null ||
                    database.Users.Count == 0 ||
                    database.Users.Any(u =>
                        u == null ||
                        string.IsNullOrWhiteSpace(u.Username)))
                {
                    throw new CryptographicException(
                        "Неверная парольная фраза или " +
                        "некорректное содержимое файла.");
                }

                // Правильность парольной фразы дополнительно
                // проверяется по наличию учётной записи ADMIN.
                int adminCount = database.Users.Count(u =>
                    string.Equals(
                        u.Username,
                        "ADMIN",
                        StringComparison.OrdinalIgnoreCase));

                if (adminCount != 1)
                {
                    throw new CryptographicException(
                        "Неверная парольная фраза или файл повреждён.");
                }

                // Запрещаем повторяющиеся имена пользователей.
                bool hasDuplicates = database.Users
                    .GroupBy(u => u.Username,
                        StringComparer.OrdinalIgnoreCase)
                    .Any(group => group.Count() > 1);

                if (hasDuplicates)
                {
                    throw new InvalidDataException(
                        "В файле обнаружены повторяющиеся имена.");
                }

                return database.Users;
            }
            finally
            {
                // Расшифрованные байты удаляем из используемого массива.
                CryptographicOperations.ZeroMemory(plaintext);
            }
        }

        // Сериализует список, шифрует его и заменяет старый файл.
        public void SaveUsers(
            List<User> users,
            string passPhrase)
        {
            ValidateUsers(users);

            var database = new UserDatabase
            {
                FormatVersion = 1,
                Users = users
            };

            string json = JsonSerializer.Serialize(
                database, _jsonOptions);

            byte[] plaintext = Encoding.UTF8.GetBytes(json);
            byte[] encryptedData = _crypto.Encrypt(
                plaintext, passPhrase);

            string temporaryPath = FilePath + ".tmp";

            try
            {
                // Временный файл содержит только зашифрованные данные.
                File.WriteAllBytes(temporaryPath, encryptedData);

                // Перемещаем новый файл на место старого.
                // Старое содержимое файла заменяется.
                File.Move(temporaryPath, FilePath, true);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(plaintext);
                CryptographicOperations.ZeroMemory(encryptedData);

                if (File.Exists(temporaryPath))
                {
                    File.Delete(temporaryPath);
                }
            }
        }

        private static void ValidateUsers(List<User> users)
        {
            if (users == null || users.Count == 0 ||
                users.Any(u =>
                    u == null ||
                    string.IsNullOrWhiteSpace(u.Username)))
            {
                throw new ArgumentException(
                    "Список пользователей некорректен.");
            }

            int adminCount = users.Count(u =>
                string.Equals(
                    u.Username,
                    "ADMIN",
                    StringComparison.OrdinalIgnoreCase));

            if (adminCount != 1)
            {
                throw new InvalidOperationException(
                    "В хранилище должна быть ровно одна " +
                    "учётная запись ADMIN.");
            }

            bool hasDuplicates = users
                .GroupBy(u => u.Username,
                    StringComparer.OrdinalIgnoreCase)
                .Any(group => group.Count() > 1);

            if (hasDuplicates)
            {
                throw new InvalidOperationException(
                    "Имена пользователей должны быть уникальными.");
            }
        }
    }
}