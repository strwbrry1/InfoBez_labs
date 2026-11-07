using PasswordManager.Forms;
using PasswordManager.Models;
using PasswordManager.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManager.Forms
{
    public partial class FormAdmin : Form
    {
        private readonly List<User> _users;

        private readonly User _currentUser;

        private readonly Action _saveChanges;

        private readonly PasswordService _passwordService = new();

        public FormAdmin(
            List<User> users,
            User currentUser,
            Action saveChanges)
        {
            InitializeComponent();

            _users = users;
            _currentUser = currentUser;
            _saveChanges = saveChanges;

            Text = "Панель администратора";

            labelWelcome.Text =
                $"Вы вошли как {_currentUser.Username}. " +
                "Режим администратора.";

            // Связываем пункты меню с обработчиками.
            menuManageUsers.Click += menuManageUsers_Click;
            menuChangePassword.Click += menuChangePassword_Click;
            menuAbout.Click += menuAbout_Click;
            menuExit.Click += menuExit_Click;


            MainMenuStrip = menuStripMain;
        }

        // Открытие управления пользователями.
        private void menuManageUsers_Click(
            object? sender,
            EventArgs e)
        {
            using FormUserManagement form =
                new FormUserManagement(_users, _saveChanges);

            form.ShowDialog(this);
        }

        // Смена пароля администратора.
        private void menuChangePassword_Click(
            object? sender,
            EventArgs e)
        {
            string oldHash = _currentUser.PasswordHash;
            DateTime? oldChangedAt = _currentUser.PasswordChangedAt;

            using FormChangePassword form =
                new FormChangePassword(
                    _currentUser,
                    _passwordService);

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _saveChanges();

                MessageBox.Show(
                    "Пароль администратора успешно изменён.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Откатываем изменение, если файл не удалось сохранить.
                _currentUser.PasswordHash = oldHash;
                _currentUser.PasswordChangedAt = oldChangedAt;

                MessageBox.Show(
                    "Не удалось сохранить новый пароль:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // О программе.
        private void menuAbout_Click(
            object? sender,
            EventArgs e)
        {
            using FormAbout form = new FormAbout();

            form.ShowDialog(this);
        }

        // Выход из приложения.
        private void menuExit_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}