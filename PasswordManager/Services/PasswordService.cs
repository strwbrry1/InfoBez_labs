using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PasswordManager.Models;

namespace PasswordManager.Services
{
    public class PasswordService
    {
        // Вычисляет MD4 и сохраняет результат в шестнадцатеричном виде.
        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException(
                    "Пароль не должен быть пустым.",
                    nameof(password));
            }

            byte[] input = Encoding.UTF8.GetBytes(password);
            byte[] hash = Md4Hash.ComputeHash(input);

            try
            {
                return Convert.ToHexString(hash);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(input);
                CryptographicOperations.ZeroMemory(hash);
            }
        }

        // Сравнивает хэш введённого пароля с сохранённым хэшем.
        public bool VerifyPassword(string password, string savedHash)
        {
            if (string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(savedHash))
            {
                return false;
            }

            byte[] input = Encoding.UTF8.GetBytes(password);
            byte[] actualHash = Md4Hash.ComputeHash(input);

            try
            {
                byte[] expectedHash;

                try
                {
                    expectedHash = Convert.FromHexString(savedHash);
                }
                catch (FormatException)
                {
                    return false;
                }

                try
                {
                    return actualHash.Length == expectedHash.Length &&
                           CryptographicOperations.FixedTimeEquals(
                               actualHash,
                               expectedHash);
                }
                finally
                {
                    CryptographicOperations.ZeroMemory(expectedHash);
                }
            }
            finally
            {
                CryptographicOperations.ZeroMemory(input);
                CryptographicOperations.ZeroMemory(actualHash);
            }
        }

        // Проверяет пароль с учётом настроек конкретного пользователя.
        public bool ValidatePassword(
            string password,
            User user,
            out string errorMessage)
        {
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Пароль не может быть пустым.";
                return false;
            }

            // Минимальная длина проверяется всегда,
            // независимо от включения дополнительных ограничений.
            if (password.Length < user.MinPasswordLength)
            {
                errorMessage =
                    $"Пароль должен содержать не менее " +
                    $"{user.MinPasswordLength} символов.";

                return false;
            }

            // Дополнительные требования из варианта.
            if (user.PasswordRestrictionsEnabled)
            {
                if (!password.Any(char.IsLower))
                {
                    errorMessage =
                        "Пароль должен содержать строчную букву.";
                    return false;
                }

                if (!password.Any(char.IsUpper))
                {
                    errorMessage =
                        "Пароль должен содержать прописную букву.";
                    return false;
                }

                if (!password.Any(char.IsDigit))
                {
                    errorMessage =
                        "Пароль должен содержать цифру.";
                    return false;
                }

                // Арифметические операции: +, -, * и /.
                if (!password.Any(c => "+-*/".Contains(c)))
                {
                    errorMessage =
                        "Пароль должен содержать знак арифметической " +
                        "операции: +, -, * или /.";
                    return false;
                }
            }

            errorMessage = "";
            return true;
        }

        public bool IsPasswordExpired(User user, DateTime? currentTime = null)
        {
            if (string.IsNullOrEmpty(user.PasswordHash))
                return false;

            if (user.PasswordExpirationMonths == 0)
                return false;

            // Если пароль установлен, но дата его установки отсутствует,
            // считаем его требующим замены.
            if (user.PasswordChangedAt == null)
                return true;

            DateTime now = currentTime ?? DateTime.Now;

            DateTime expirationDate = user.PasswordChangedAt.Value.AddMonths(
                user.PasswordExpirationMonths);

            return now >= expirationDate;
        }
    }
}