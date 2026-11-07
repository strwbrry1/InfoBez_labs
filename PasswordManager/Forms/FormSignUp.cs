using System;
using System.Windows.Forms;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager
{
    public partial class FormSignUp : Form
    {
        private User? _user;
        private PasswordService? _passwordService;

        public FormSignUp()
        {
            InitializeComponent();

            buttonLogin.Click += buttonLogin_Click;
            buttonExit.Click += buttonExit_Click;

            textBoxPassword.PasswordChar = '*';
            textBox1.PasswordChar = '*';

            AcceptButton = buttonLogin;
            CancelButton = buttonExit;
        }

        public FormSignUp(
            User user,
            PasswordService passwordService) : this()
        {
            _user = user;
            _passwordService = passwordService;

            // Логин уже зарегистрирован администратором.
            textBoxLogin.Text = user.Username;
            textBoxLogin.ReadOnly = true;

            label1.Text = "Пользователь";
            label2.Text = "Новый пароль";
            label3.Text = "Повторите пароль";

            textBoxPassword.PlaceholderText = "Введите новый пароль";
            textBox1.PlaceholderText = "Повторите новый пароль";

            buttonLogin.Text = "Установить";
            buttonExit.Text = "Отмена";

            Text = "Установка пароля";
        }

        private void buttonLogin_Click(object? sender, EventArgs e)
        {
            if (_user == null || _passwordService == null)
            {
                MessageBox.Show(
                    "Форма открыта без учётной записи пользователя.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            string password = textBoxPassword.Text;
            string repeatedPassword = textBox1.Text;

            if (password != repeatedPassword)
            {
                MessageBox.Show(
                    "Введённые пароли не совпадают.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox1.Clear();
                textBox1.Focus();
                return;
            }

            if (!_passwordService.ValidatePassword(
                password,
                _user,
                out string errorMessage))
            {
                MessageBox.Show(
                    errorMessage,
                    "Пароль не соответствует требованиям",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxPassword.Clear();
                textBox1.Clear();
                textBoxPassword.Focus();
                return;
            }

            try
            {
                _user.PasswordHash =
                    _passwordService.HashPassword(password);

                _user.PasswordChangedAt = DateTime.Now;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить хэш пароля:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}