using System;
using System.Windows.Forms;
using PasswordManager.Models;

namespace PasswordManager.Forms
{
    public partial class FormUserSettings : Form
    {
        public bool RestrictionsEnabled =>
            checkBoxRestrictions.Checked;

        public int MinPasswordLength =>
            (int)numericMinLength.Value;

        public int PasswordExpirationMonths =>
            (int)numericExpiration.Value;

        public FormUserSettings(User user)
        {
            InitializeComponent();

            label1.Text = $"Пользователь: {user.Username}";

            checkBoxRestrictions.Checked =
                user.PasswordRestrictionsEnabled;

            numericMinLength.Value = Math.Clamp(
                user.MinPasswordLength,
                (int)numericMinLength.Minimum,
                (int)numericMinLength.Maximum);

            numericExpiration.Value = Math.Clamp(
                user.PasswordExpirationMonths,
                (int)numericExpiration.Minimum,
                (int)numericExpiration.Maximum);

            buttonSave.Click += buttonSave_Click;
            buttonCancel.Click += buttonCancel_Click;

            buttonSave.DialogResult = DialogResult.None;
            buttonCancel.DialogResult = DialogResult.Cancel;

            AcceptButton = buttonSave;
            CancelButton = buttonCancel;
        }

        private void buttonSave_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}