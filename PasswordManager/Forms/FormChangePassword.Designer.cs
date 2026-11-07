namespace PasswordManager.Forms
{
    partial class FormChangePassword
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
            label3 = new Label();
            textBoxRepeatPassword = new TextBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            label2 = new Label();
            label1 = new Label();
            textBoxNewPassword = new TextBox();
            textBoxOldPassword = new TextBox();
            labelInfo = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 173);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 17;
            label3.Text = "Подтвердите пароль";
            // 
            // textBoxRepeatPassword
            // 
            textBoxRepeatPassword.BackColor = SystemColors.ControlLightLight;
            textBoxRepeatPassword.ForeColor = SystemColors.InfoText;
            textBoxRepeatPassword.Location = new Point(12, 197);
            textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            textBoxRepeatPassword.PasswordChar = '*';
            textBoxRepeatPassword.PlaceholderText = "Повторите новый пароль";
            textBoxRepeatPassword.Size = new Size(291, 23);
            textBoxRepeatPassword.TabIndex = 16;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Coral;
            buttonCancel.Location = new Point(228, 235);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.LightGreen;
            buttonSave.Location = new Point(12, 235);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 112);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 13;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 12;
            label1.Text = "Текущий пароль";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.BackColor = SystemColors.ControlLightLight;
            textBoxNewPassword.ForeColor = SystemColors.InfoText;
            textBoxNewPassword.Location = new Point(12, 136);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.PlaceholderText = "Введите новый пароль";
            textBoxNewPassword.Size = new Size(291, 23);
            textBoxNewPassword.TabIndex = 11;
            // 
            // textBoxOldPassword
            // 
            textBoxOldPassword.Location = new Point(12, 74);
            textBoxOldPassword.Name = "textBoxOldPassword";
            textBoxOldPassword.PasswordChar = '*';
            textBoxOldPassword.PlaceholderText = "Введите текущий пароль";
            textBoxOldPassword.Size = new Size(291, 23);
            textBoxOldPassword.TabIndex = 10;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(12, 9);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(38, 15);
            labelInfo.TabIndex = 18;
            labelInfo.Text = "label4";
            // 
            // FormChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 276);
            Controls.Add(labelInfo);
            Controls.Add(label3);
            Controls.Add(textBoxRepeatPassword);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxNewPassword);
            Controls.Add(textBoxOldPassword);
            Name = "FormChangePassword";
            Text = "FormChangePassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox textBoxRepeatPassword;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label2;
        private Label label1;
        private TextBox textBoxNewPassword;
        private TextBox textBoxOldPassword;
        private Label labelInfo;
    }
}