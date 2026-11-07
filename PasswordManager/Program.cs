using PasswordManager.Forms;
using PasswordManager.Models;
using PasswordManager.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var storage = new UserStorageService();
            var passwordService = new PasswordService();

            bool firstRun = !storage.StorageExists;

            // 1. Запрашиваем парольную фразу.
            using var startup = new FormStartup(firstRun);

            if (startup.ShowDialog() != DialogResult.OK)
                return;

            string passPhrase = startup.PassPhrase;

            List<User> users;

            // 2. Создаём и открываем защищённое хранилище.
            try
            {
                if (firstRun)
                {
                    storage.CreateInitialStorage(passPhrase);
                }

                users = storage.LoadUsers(passPhrase);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось открыть хранилище.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Все операции сохранения используют один список
            // и текущую парольную фразу.
            void SaveChanges()
            {
                storage.SaveUsers(users, passPhrase);
            }

            // 3. Авторизация.
            using var signIn = new FormSignIn(users);

            if (signIn.ShowDialog() != DialogResult.OK ||
                signIn.AuthenticatedUser == null)
            {
                return;
            }

            User currentUser = signIn.AuthenticatedUser;

            // 4. При первом входе необходимо установить пароль.
            if (string.IsNullOrEmpty(currentUser.PasswordHash))
            {
                using var signUp = new FormSignUp(
                    currentUser,
                    passwordService);

                if (signUp.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось сохранить новый пароль.\n\n" +
                        ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            // 5. Проверяем срок действия установленного пароля.
            if (passwordService.IsPasswordExpired(currentUser))
            {
                using var changePassword = new FormChangePassword(
                    currentUser,
                    passwordService,
                    passwordExpired: true);

                // При отказе от смены просроченного пароля
                // доступ к главному окну не предоставляется.
                if (changePassword.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось сохранить новый пароль.\n\n" +
                        ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }

            // 6. Запускаем форму согласно роли пользователя.
            try
            {
                if (string.Equals(
                    currentUser.Username,
                    "ADMIN",
                    StringComparison.OrdinalIgnoreCase))
                {
                    using var adminForm = new FormAdmin(
                        users,
                        currentUser,
                        SaveChanges);

                    Application.Run(adminForm);
                }
                else
                {
                    using var userForm = new FormUser(
                        currentUser,
                        SaveChanges);

                    Application.Run(userForm);
                }
            }
            finally
            {
                // Дополнительно сохраняем актуальное состояние
                // после закрытия главной формы.
                try
                {
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось сохранить изменения при завершении.\n\n" +
                        ex.Message,
                        "Ошибка сохранения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}