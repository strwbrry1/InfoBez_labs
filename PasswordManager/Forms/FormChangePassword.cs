using PasswordManager.Models;
using PasswordManager.Services;
using System;
using System.Windows.Forms;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace PasswordManager.Forms
{
    public partial class FormChangePassword : Form
    {
        private readonly User _user;

        private readonly PasswordService _passwordService;

        public FormChangePassword(
            User user,
            PasswordService passwordService,
            bool passwordExpired = false)
        {
            InitializeComponent();

            _user = user;
            _passwordService = passwordService;

            textBoxOldPassword.UseSystemPasswordChar = true;
            textBoxNewPassword.UseSystemPasswordChar = true;
            textBoxRepeatPassword.UseSystemPasswordChar = true;

            if (passwordExpired)
            {
                Text = "Срок действия пароля истёк";

                labelInfo.Text =
                    "Срок действия вашего пароля истёк. " +
                    "Необходимо установить новый пароль.";
            }
            else
            {
                Text = "Смена пароля";

                labelInfo.Text =
                    $"Изменение пароля пользователя {_user.Username}";
            }

            buttonSave.Click += buttonSave_Click;
            buttonCancel.Click += buttonCancel_Click;

            AcceptButton = buttonSave;
            CancelButton = buttonCancel;
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            string oldPassword = textBoxOldPassword.Text;
            string newPassword = textBoxNewPassword.Text;
            string repeatedPassword = textBoxRepeatPassword.Text;

            // 1. Проверка старого пароля.
            if (string.IsNullOrEmpty(oldPassword) ||
                !_passwordService.VerifyPassword(
                    oldPassword,
                    _user.PasswordHash))
            {
                MessageBox.Show(
                    "Старый пароль введён неправильно.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxOldPassword.Clear();
                textBoxOldPassword.Focus();

                return;
            }

            // 2. Проверка подтверждения нового пароля.
            if (newPassword != repeatedPassword)
            {
                MessageBox.Show(
                    "Новые пароли не совпадают.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxRepeatPassword.Clear();
                textBoxRepeatPassword.Focus();

                return;
            }

            // 3. Проверка требований к новому паролю.
            if (!_passwordService.ValidatePassword(
                newPassword,
                _user,
                out string errorMessage))
            {
                MessageBox.Show(
                    errorMessage,
                    "Пароль не соответствует требованиям",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNewPassword.Clear();
                textBoxRepeatPassword.Clear();
                textBoxNewPassword.Focus();

                return;
            }

            try
            {
                // 4. Рассчитываем новый хэш.
                string newHash =
                    _passwordService.HashPassword(newPassword);

                // 5. Обновляем информацию об учётной записи.
                _user.PasswordHash = newHash;
                _user.PasswordChangedAt = DateTime.Now;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось изменить пароль:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}