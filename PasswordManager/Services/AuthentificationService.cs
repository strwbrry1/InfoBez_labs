using System;
using System.Collections.Generic;
using System.Linq;
using PasswordManager.Models;

namespace PasswordManager.Services
{
    public enum AuthenticationStatus
    {
        Success,
        UserNotFound,
        UserBlocked,
        WrongPassword,
        FirstLogin
    }

    public class AuthenticationService
    {
        private readonly PasswordService _passwordService;

        public AuthenticationService(PasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public AuthenticationStatus Authenticate(
            List<User> users,
            string username,
            string password,
            out User? authenticatedUser)
        {
            authenticatedUser = null;

            if (string.IsNullOrWhiteSpace(username))
            {
                return AuthenticationStatus.UserNotFound;
            }

            string normalizedUsername = username.Trim();

            User? user = users.FirstOrDefault(u =>
                string.Equals(
                    u.Username,
                    normalizedUsername,
                    StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return AuthenticationStatus.UserNotFound;
            }

            authenticatedUser = user;

            if (user.IsBlocked)
            {
                return AuthenticationStatus.UserBlocked;
            }

            // Пустой хэш означает, что пароль ещё не установлен.
            // В этом состоянии разрешаем только первый вход
            // с пустым полем старого пароля.
            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                return string.IsNullOrEmpty(password)
                    ? AuthenticationStatus.FirstLogin
                    : AuthenticationStatus.WrongPassword;
            }

            bool passwordIsCorrect =
                _passwordService.VerifyPassword(
                    password,
                    user.PasswordHash);

            return passwordIsCorrect
                ? AuthenticationStatus.Success
                : AuthenticationStatus.WrongPassword;
        }
    }
}