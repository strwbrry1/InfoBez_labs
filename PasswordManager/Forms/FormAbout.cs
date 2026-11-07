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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            Text = "О программе";

            labelTitle.Text =
                "Лабораторная работа № 1\n" +
                "Разграничение полномочий пользователей";

            labelAuthor.Text =
                "Автор: Матвиенко Семён; ПИбд-43";

            labelEncryption.Text =
                "Алгоритм шифрования: DES, режим OFB";

            labelHash.Text =
                "Алгоритм хэширования: MD4";

            labelRestrictions.Text =
                "Требования к паролю:\n" +
                "• строчные и прописные буквы;\n" +
                "• цифры;\n" +
                "• знаки арифметических операций (+, -, *, /).";

            buttonClose.Click += buttonClose_Click;

            AcceptButton = buttonClose;
        }

        private void buttonClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
