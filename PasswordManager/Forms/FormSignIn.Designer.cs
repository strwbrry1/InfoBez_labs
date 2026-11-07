namespace PasswordManager
{
    partial class FormSignIn
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
            label2 = new Label();
            label1 = new Label();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            buttonExit = new Button();
            buttonLogin = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 9;
            label2.Text = "Пароль";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 8;
            label1.Text = "Логин";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = SystemColors.ControlLightLight;
            textBoxPassword.ForeColor = SystemColors.InfoText;
            textBoxPassword.Location = new Point(12, 99);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Введите пароль";
            textBoxPassword.Size = new Size(291, 23);
            textBoxPassword.TabIndex = 7;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(12, 37);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.PlaceholderText = "Введите логин";
            textBoxLogin.Size = new Size(291, 23);
            textBoxLogin.TabIndex = 6;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.Coral;
            buttonExit.Location = new Point(228, 128);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 11;
            buttonExit.Text = "Cancel";
            buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Location = new Point(12, 128);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 10;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = false;
            // 
            // FormSignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 159);
            Controls.Add(buttonExit);
            Controls.Add(buttonLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Name = "FormSignIn";
            Text = "FormSignIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Button buttonExit;
        private Button buttonLogin;
    }
}