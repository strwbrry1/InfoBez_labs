using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    public class UserDatabase
    {
        public int FormatVersion { get; set; } = 1;

        public List<User> Users { get; set; } = new();
    }
}
