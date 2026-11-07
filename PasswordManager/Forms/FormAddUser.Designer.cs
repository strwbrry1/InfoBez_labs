namespace PasswordManager.Forms
{
    partial class FormAddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCancel = new Button();
            buttonAdd = new Button();
            label1 = new Label();
            textBoxUsername = new TextBox();
            label2 = new Label();
            checkBoxRestrictions = new CheckBox();
            numericMinLength = new NumericUpDown();
            numericExpiration = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericMinLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericExpiration).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Coral;
            buttonCancel.Location = new Point(224, 159);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.LightGreen;
            buttonAdd.Location = new Point(8, 159);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 12;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 15;
            label1.Text = "Имя пользователя";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(12, 34);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Введите логин";
            textBoxUsername.Size = new Size(130, 23);
            textBoxUsername.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 16;
            label2.Text = "Мин. длина пароля";
            // 
            // checkBoxRestrictions
            // 
            checkBoxRestrictions.AutoSize = true;
            checkBoxRestrictions.Location = new Point(165, 36);
            checkBoxRestrictions.Name = "checkBoxRestrictions";
            checkBoxRestrictions.Size = new Size(98, 19);
            checkBoxRestrictions.TabIndex = 17;
            checkBoxRestrictions.Text = "ограничения";
            checkBoxRestrictions.UseVisualStyleBackColor = true;
            // 
            // numericMinLength
            // 
            numericMinLength.Location = new Point(165, 72);
            numericMinLength.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            numericMinLength.Name = "numericMinLength";
            numericMinLength.Size = new Size(98, 23);
            numericMinLength.TabIndex = 18;
            // 
            // numericExpiration
            // 
            numericExpiration.Location = new Point(165, 121);
            numericExpiration.Maximum = new decimal(new int[] { 1200, 0, 0, 0 });
            numericExpiration.Name = "numericExpiration";
            numericExpiration.Size = new Size(98, 23);
            numericExpiration.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 20;
            label3.Text = "Срок действия (мес.)";
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 195);
            Controls.Add(label3);
            Controls.Add(numericExpiration);
            Controls.Add(numericMinLength);
            Controls.Add(checkBoxRestrictions);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxUsername);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAdd);
            Name = "FormAddUser";
            Text = "FormAddUser";
            ((System.ComponentModel.ISupportInitialize)numericMinLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericExpiration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonAdd;
        private Label label1;
        private TextBox textBoxUsername;
        private Label label2;
        private CheckBox checkBoxRestrictions;
        private NumericUpDown numericMinLength;
        private NumericUpDown numericExpiration;
        private Label label3;
    }
}