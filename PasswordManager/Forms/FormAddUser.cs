using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.Forms
{
    public partial class FormAddUser : Form
    {
        public string Username =>
            textBoxUsername.Text.Trim();

        public bool RestrictionsEnabled =>
            checkBoxRestrictions.Checked;

        public int MinPasswordLength =>
            (int)numericMinLength.Value;

        public int PasswordExpirationMonths =>
            (int)numericExpiration.Value;

        public FormAddUser()
        {
            InitializeComponent();

            buttonAdd.Click += buttonAdd_Click;
            buttonCancel.Click += buttonCancel_Click;

            // Кнопка добавления сама не закрывает форму.
            buttonAdd.DialogResult = DialogResult.None;

            buttonCancel.DialogResult = DialogResult.Cancel;

            AcceptButton = buttonAdd;
            CancelButton = buttonCancel;
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show(
                    "Введите имя пользователя.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxUsername.Focus();
                return;
            }

            // Результат OK возвращается только после проверки.
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