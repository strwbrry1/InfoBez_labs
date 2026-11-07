using PasswordManager.Forms;
using PasswordManager.Models;
using PasswordManager.Services;
using System;
using System.Windows.Forms;

namespace PasswordManager.Forms
{
    public partial class FormUser : Form
    {
        private readonly User _currentUser;

        private readonly Action _saveChanges;

        private readonly PasswordService _passwordService = new();

        public FormUser(
            User currentUser,
            Action saveChanges)
        {
            InitializeComponent();

            _currentUser = currentUser;
            _saveChanges = saveChanges;

            Text = "Панель пользователя";

            labelWelcome.Text =
                $"Вы вошли как {_currentUser.Username}.";

            menuChangePassword.Click += menuChangePassword_Click;
            menuExit.Click += menuExit_Click;
            menuAbout.Click += menuAbout_Click;

            MainMenuStrip = menuStripMain;
        }

        // Смена пароля.
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
                    "Пароль успешно изменён.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
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

        // Выход.
        private void menuExit_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}