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
    public partial class FormStartup : Form
    {
        public string PassPhrase { get; private set; } = "";

        private readonly bool _firstRun;

        public FormStartup() : this(true)
        {
        }

        public FormStartup(bool firstRun)
        {
            InitializeComponent();

            _firstRun = firstRun;

            // Скрываем парольную фразу в обоих полях.
            textBoxPassPhrase.PasswordChar = '*';
            textBoxRepeatPassPhrase.PasswordChar = '*';

            buttonConfirm.Click += buttonConfirm_Click;
            AcceptButton = buttonConfirm;

            if (_firstRun)
            {
                Text = "Создание защищённого хранилища";
            }
            else
            {
                Text = "Расшифрование хранилища";

                // При обычном запуске повторный ввод не нужен.
                label2.Visible = false;
                textBoxRepeatPassPhrase.Visible = false;

                buttonConfirm.Location = new Point(12, 70);
                ClientSize = new Size(313, 103);
            }
        }

        private void buttonConfirm_Click(object? sender, EventArgs e)
        {
            string passPhrase = textBoxPassPhrase.Text;

            if (string.IsNullOrEmpty(passPhrase))
            {
                MessageBox.Show(
                    "Парольная фраза не может быть пустой.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // При первом запуске требуется подтверждение.
            if (_firstRun &&
                passPhrase != textBoxRepeatPassPhrase.Text)
            {
                MessageBox.Show(
                    "Парольные фразы не совпадают.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            PassPhrase = passPhrase;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
