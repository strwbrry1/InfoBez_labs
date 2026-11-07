using System;
using System.Collections.Generic;
using System.Linq;
using PasswordManager.Models;

namespace PasswordManager.Services
{
    public class UserService
    {
        // Добавление новой учётной записи.
        public User AddUser(
            List<User> users,
            string username,
            bool restrictionsEnabled,
            int minPasswordLength,
            int passwordExpirationMonths)
        {
            username = username.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException(
                    "Введите имя пользователя.");
            }

            if (username.Length > 64)
            {
                throw new ArgumentException(
                    "Имя пользователя не должно превышать 64 символа.");
            }

            if (username.Any(char.IsControl))
            {
                throw new ArgumentException(
                    "Имя пользователя содержит недопустимые символы.");
            }

            if (string.Equals(
                username, "ADMIN",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "Имя ADMIN зарезервировано.");
            }

            if (minPasswordLength < 0 ||
                passwordExpirationMonths < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Параметры пароля не могут быть отрицательными.");
            }

            bool alreadyExists = users.Any(u =>
                string.Equals(
                    u.Username,
                    username,
                    StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                throw new InvalidOperationException(
                    "Пользователь с таким именем уже существует.");
            }

            User user = new User
            {
                Username = username,
                PasswordHash = "",
                IsBlocked = false,
                PasswordRestrictionsEnabled = restrictionsEnabled,
                MinPasswordLength = minPasswordLength,
                PasswordExpirationMonths = passwordExpirationMonths,
                PasswordChangedAt = null
            };

            users.Add(user);

            return user;
        }

        // Блокировка или разблокировка учётной записи.
        public void SetBlocked(User user, bool blocked)
        {
            if (string.Equals(
                user.Username,
                "ADMIN",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "Нельзя заблокировать учётную запись ADMIN.");
            }

            user.IsBlocked = blocked;
        }

        // Изменение требований к паролю конкретного пользователя.
        public void UpdatePasswordPolicy(
            User user,
            bool restrictionsEnabled,
            int minPasswordLength,
            int passwordExpirationMonths)
        {
            if (minPasswordLength < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(minPasswordLength));
            }

            if (passwordExpirationMonths < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(passwordExpirationMonths));
            }

            user.PasswordRestrictionsEnabled = restrictionsEnabled;
            user.MinPasswordLength = minPasswordLength;
            user.PasswordExpirationMonths = passwordExpirationMonths;
        }
    }
}