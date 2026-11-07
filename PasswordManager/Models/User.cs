using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class User
    {
        public string Username { get; set; } = "";

        // Пустая строка означает, что пользователь ещё не установил пароль
        public string PasswordHash { get; set; } = "";

        public bool IsBlocked { get; set; } = false;

        public bool PasswordRestrictionsEnabled { get; set; } = false;

        // Значение 0 означает отсутствие ограничения по длине
        public int MinPasswordLength { get; set; } = 0;

        // Значение 0 означает бессрочный пароль
        public int PasswordExpirationMonths { get; set; } = 0;

        public DateTime? PasswordChangedAt { get; set; } = null;
    }
}
