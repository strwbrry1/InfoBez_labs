using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Services
{
    public class CryptoService
    {
        private static readonly byte[] Magic =
            Encoding.ASCII.GetBytes("PMGR1");

        private const int IvSize = 8;
        private const int DesBlockSize = 8;

        // Шифрует данные и возвращает готовое содержимое файла.
        public byte[] Encrypt(byte[] plaintext, string passPhrase)
        {
            ArgumentNullException.ThrowIfNull(plaintext);

            byte[] key = DeriveKey(passPhrase);

            try
            {
                // Для OFB необходим вектор инициализации.
                byte[] iv = RandomNumberGenerator.GetBytes(IvSize);

                byte[] ciphertext = ApplyOfb(plaintext, key, iv);

                // Формат: заголовок + IV + шифротекст.
                byte[] result = new byte[
                    Magic.Length + IvSize + ciphertext.Length];

                Buffer.BlockCopy(
                    Magic, 0, result, 0, Magic.Length);

                Buffer.BlockCopy(
                    iv, 0, result, Magic.Length, IvSize);

                Buffer.BlockCopy(
                    ciphertext,
                    0,
                    result,
                    Magic.Length + IvSize,
                    ciphertext.Length);

                return result;
            }
            finally
            {
                CryptographicOperations.ZeroMemory(key);
            }
        }

        // Расшифровывает содержимое файла.
        public byte[] Decrypt(byte[] encryptedData, string passPhrase)
        {
            ArgumentNullException.ThrowIfNull(encryptedData);

            int headerSize = Magic.Length + IvSize;

            if (encryptedData.Length < headerSize ||
                !encryptedData.AsSpan(0, Magic.Length).SequenceEqual(Magic))
            {
                throw new InvalidDataException(
                    "Файл не соответствует формату хранилища.");
            }

            byte[] iv = new byte[IvSize];

            Buffer.BlockCopy(
                encryptedData, Magic.Length, iv, 0, IvSize);

            int ciphertextLength = encryptedData.Length - headerSize;
            byte[] ciphertext = new byte[ciphertextLength];

            Buffer.BlockCopy(
                encryptedData,
                headerSize,
                ciphertext,
                0,
                ciphertextLength);

            byte[] key = DeriveKey(passPhrase);

            try
            {
                // В OFB для шифрования и расшифрования
                // используется одна и та же операция.
                return ApplyOfb(ciphertext, key, iv);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(key);
            }
        }

        // Детерминированно получает 8-байтовый ключ DES.
        // Случайная добавка к ключу не используется.
        private static byte[] DeriveKey(string passPhrase)
        {
            if (string.IsNullOrEmpty(passPhrase))
            {
                throw new ArgumentException(
                    "Парольная фраза не должна быть пустой.",
                    nameof(passPhrase));
            }

            byte[] phraseBytes = Encoding.UTF8.GetBytes(passPhrase);
            byte[] digest = Md4Hash.ComputeHash(phraseBytes);

            try
            {
                // MD4 выдаёт 16 байт, DES принимает ключ длиной 8 байт.
                byte[] key = digest[..8];

                if (DES.IsWeakKey(key) || DES.IsSemiWeakKey(key))
                {
                    CryptographicOperations.ZeroMemory(key);

                    throw new CryptographicException(
                        "Получен слабый ключ DES. " +
                        "Выберите другую парольную фразу.");
                }

                return key;
            }
            finally
            {
                CryptographicOperations.ZeroMemory(phraseBytes);
                CryptographicOperations.ZeroMemory(digest);
            }
        }

        // Реализация OFB поверх встроенного блочного шифра DES.
        private static byte[] ApplyOfb(
            byte[] input,
            byte[] key,
            byte[] iv)
        {
            byte[] output = new byte[input.Length];
            byte[] feedback = (byte[])iv.Clone();
            byte[] keyStream = new byte[DesBlockSize];

            using DES des = DES.Create();

            // DES здесь используется как блочный шифр.
            // Режим OFB реализуется этим методом.
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.None;
            des.Key = key;

            using ICryptoTransform encryptor = des.CreateEncryptor();

            for (int offset = 0; offset < input.Length;
                 offset += DesBlockSize)
            {
                // Генерируем очередной блок ключевого потока.
                int written = encryptor.TransformBlock(
                    feedback,
                    0,
                    DesBlockSize,
                    keyStream,
                    0);

                if (written != DesBlockSize)
                {
                    throw new CryptographicException(
                        "Не удалось сформировать блок DES.");
                }

                // Выход предыдущего шифрования становится
                // входом для следующего блока OFB.
                Buffer.BlockCopy(
                    keyStream, 0, feedback, 0, DesBlockSize);

                int count = Math.Min(
                    DesBlockSize,
                    input.Length - offset);

                // XOR с ключевым потоком.
                for (int i = 0; i < count; i++)
                {
                    output[offset + i] =
                        (byte)(input[offset + i] ^ keyStream[i]);
                }
            }

            CryptographicOperations.ZeroMemory(feedback);
            CryptographicOperations.ZeroMemory(keyStream);

            return output;
        }
    }
}