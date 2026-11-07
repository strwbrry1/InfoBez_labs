using PasswordManager.Forms;
using PasswordManager.Models;
using PasswordManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManager.Forms
{
    public partial class FormUserManagement : Form
    {
        private readonly List<User> _users;

        private readonly UserService _userService = new();

        // Делегат сохранения передаётся из Program.cs.
        private readonly Action _saveChanges;

        public FormUserManagement(
            List<User> users,
            Action saveChanges)
        {
            InitializeComponent();

            _users = users;
            _saveChanges = saveChanges;

            buttonAddUser.Click += buttonAddUser_Click;
            buttonToggleBlock.Click += buttonToggleBlock_Click;
            buttonEditSettings.Click += buttonEditSettings_Click;
            buttonClose.Click += buttonClose_Click;

            ConfigureGrid();
            RefreshGrid();
        }

        private void ConfigureGrid()
        {
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.MultiSelect = false;

            dataGridViewUsers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewUsers.RowHeadersVisible = false;

            dataGridViewUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Обновление таблицы.
        private void RefreshGrid()
        {
            dataGridViewUsers.Rows.Clear();

            foreach (User user in _users.OrderBy(
                u => u.Username,
                StringComparer.OrdinalIgnoreCase))
            {
                int rowIndex = dataGridViewUsers.Rows.Add(
                    user.Username,
                    user.IsBlocked ? "Да" : "Нет",
                    user.PasswordRestrictionsEnabled
                        ? "Включены"
                        : "Выключены",
                    user.MinPasswordLength,
                    user.PasswordExpirationMonths);

                // Связываем строку таблицы с объектом User.
                dataGridViewUsers.Rows[rowIndex].Tag = user;
            }
        }

        // Получение выбранного пользователя.
        private User? GetSelectedUser()
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                return null;
            }

            return dataGridViewUsers.SelectedRows[0].Tag as User;
        }

        // Добавление пользователя.
        private void buttonAddUser_Click(object? sender, EventArgs e)
        {
            using FormAddUser dialog = new FormAddUser();

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            User? newUser = null;

            try
            {
                newUser = _userService.AddUser(
                    _users,
                    dialog.Username,
                    dialog.RestrictionsEnabled,
                    dialog.MinPasswordLength,
                    dialog.PasswordExpirationMonths);

                // Сразу сохраняем изменения.
                _saveChanges();

                RefreshGrid();

                MessageBox.Show(
                    "Пользователь успешно добавлен.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Если сохранение не удалось, откатываем добавление.
                if (newUser != null)
                {
                    _users.Remove(newUser);
                }

                RefreshGrid();

                MessageBox.Show(
                    ex.Message,
                    "Ошибка добавления пользователя",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Блокировка / разблокировка.
        private void buttonToggleBlock_Click(
            object? sender,
            EventArgs e)
        {
            User? user = GetSelectedUser();

            if (user == null)
            {
                MessageBox.Show(
                    "Сначала выберите пользователя.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool previousValue = user.IsBlocked;

            try
            {
                _userService.SetBlocked(
                    user,
                    !user.IsBlocked);

                _saveChanges();

                RefreshGrid();
            }
            catch (Exception ex)
            {
                // Возвращаем старое состояние при ошибке.
                user.IsBlocked = previousValue;

                RefreshGrid();

                MessageBox.Show(
                    ex.Message,
                    "Ошибка блокировки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Изменение требований к паролю.
        private void buttonEditSettings_Click(
            object? sender,
            EventArgs e)
        {
            User? user = GetSelectedUser();

            if (user == null)
            {
                MessageBox.Show(
                    "Сначала выберите пользователя.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using FormUserSettings dialog =
                new FormUserSettings(user);

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            // Сохраняем прежние значения для отката.
            bool oldRestrictions =
                user.PasswordRestrictionsEnabled;

            int oldMinLength =
                user.MinPasswordLength;

            int oldExpiration =
                user.PasswordExpirationMonths;

            try
            {
                _userService.UpdatePasswordPolicy(
                    user,
                    dialog.RestrictionsEnabled,
                    dialog.MinPasswordLength,
                    dialog.PasswordExpirationMonths);

                _saveChanges();

                RefreshGrid();
            }
            catch (Exception ex)
            {
                user.PasswordRestrictionsEnabled = oldRestrictions;
                user.MinPasswordLength = oldMinLength;
                user.PasswordExpirationMonths = oldExpiration;

                RefreshGrid();

                MessageBox.Show(
                    ex.Message,
                    "Ошибка изменения параметров",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}