using PasswordManager.Models;
using PasswordManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class FormSignIn : Form
    {
        private readonly List<User> _users;
        private readonly AuthenticationService _authenticationService;

        private int _failedPasswordAttempts = 0;

        public User? AuthenticatedUser { get; private set; }

        public FormSignIn() : this(new List<User>())
        {
        }

        public FormSignIn(List<User> users)
        {
            InitializeComponent();

            _users = users;

            _authenticationService = new AuthenticationService(
                new PasswordService());

            textBoxPassword.PasswordChar = '*';

            buttonLogin.Click += buttonLogin_Click;
            buttonExit.Click += buttonExit_Click;

            buttonExit.Text = "Выход";

            AcceptButton = buttonLogin;
            CancelButton = buttonExit;

            Text = "Вход в систему";
        }

        private void buttonLogin_Click(object? sender, EventArgs e)
        {
            string username = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Введите имя пользователя.",
                    "Вход",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxLogin.Focus();
                return;
            }

            AuthenticationStatus status;
            User? user;

            try
            {
                status = _authenticationService.Authenticate(
                    _users,
                    username,
                    password,
                    out user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при проверке пароля:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            switch (status)
            {
                case AuthenticationStatus.UserNotFound:
                    MessageBox.Show(
                        "Пользователь с таким именем не зарегистрирован.",
                        "Ошибка входа",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxLogin.Focus();
                    return;

                case AuthenticationStatus.UserBlocked:
                    MessageBox.Show(
                        "Эта учётная запись заблокирована.",
                        "Доступ запрещён",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;

                case AuthenticationStatus.WrongPassword:
                    _failedPasswordAttempts++;

                    if (_failedPasswordAttempts >= 3)
                    {
                        MessageBox.Show(
                            "Три попытки ввода пароля были неудачными. " +
                            "Работа программы будет завершена.",
                            "Доступ запрещён",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        DialogResult = DialogResult.Abort;
                        Close();
                        return;
                    }

                    int remainingAttempts =
                        3 - _failedPasswordAttempts;

                    MessageBox.Show(
                        $"Неверный пароль. Осталось попыток: " +
                        $"{remainingAttempts}.",
                        "Ошибка входа",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                    return;

                case AuthenticationStatus.FirstLogin:
                case AuthenticationStatus.Success:
                    AuthenticatedUser = user;
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
            }
        }

        private void buttonExit_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
