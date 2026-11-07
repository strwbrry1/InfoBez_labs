using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PasswordManager.Services
{
    public static class Md4Hash
    {
        private const uint ProviderTypeRsaFull = 1;
        private const uint CryptVerifyContext = 0xF0000000;
        private const uint AlgorithmMd4 = 0x00008002;
        private const uint HashValueParameter = 0x0002;

        private const string ProviderName =
            "Microsoft Enhanced Cryptographic Provider v1.0";

        [DllImport(
            "advapi32.dll",
            EntryPoint = "CryptAcquireContextW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptAcquireContext(
            out IntPtr provider,
            string? container,
            string? providerName,
            uint providerType,
            uint flags);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptCreateHash(
            IntPtr provider,
            uint algorithmId,
            IntPtr key,
            uint flags,
            out IntPtr hash);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptHashData(
            IntPtr hash,
            byte[] data,
            uint dataLength,
            uint flags);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptGetHashParam(
            IntPtr hash,
            uint parameter,
            [Out] byte[] data,
            ref uint dataLength,
            uint flags);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptDestroyHash(IntPtr hash);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptReleaseContext(
            IntPtr provider,
            uint flags);

        public static byte[] ComputeHash(byte[] data)
        {
            ArgumentNullException.ThrowIfNull(data);

            IntPtr provider = IntPtr.Zero;
            IntPtr hash = IntPtr.Zero;

            try
            {
                // Получаем доступ к системному криптопровайдеру.
                if (!CryptAcquireContext(
                    out provider,
                    null,
                    ProviderName,
                    ProviderTypeRsaFull,
                    CryptVerifyContext))
                {
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error(),
                        "Не удалось открыть криптопровайдер Windows.");
                }

                // Создаём объект хэширования MD4.
                if (!CryptCreateHash(
                    provider,
                    AlgorithmMd4,
                    IntPtr.Zero,
                    0,
                    out hash))
                {
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error(),
                        "Криптопровайдер не смог создать хэш MD4.");
                }

                // Передаём данные для хэширования.
                if (data.Length > 0 &&
                    !CryptHashData(
                        hash,
                        data,
                        (uint)data.Length,
                        0))
                {
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error(),
                        "Ошибка при вычислении хэша MD4.");
                }

                // MD4 выдаёт результат длиной 16 байт.
                byte[] result = new byte[16];
                uint resultLength = (uint)result.Length;

                if (!CryptGetHashParam(
                    hash,
                    HashValueParameter,
                    result,
                    ref resultLength,
                    0))
                {
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error(),
                        "Не удалось получить результат хэширования.");
                }

                if (resultLength != result.Length)
                {
                    throw new InvalidOperationException(
                        "Криптопровайдер вернул хэш неожиданной длины.");
                }

                return result;
            }
            finally
            {
                // Освобождаем системные ресурсы.
                if (hash != IntPtr.Zero)
                    CryptDestroyHash(hash);

                if (provider != IntPtr.Zero)
                    CryptReleaseContext(provider, 0);
            }
        }
    }
}