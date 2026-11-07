namespace PasswordManager.Forms
{
    partial class FormAdmin
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
            menuStripMain = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            menuAdministration = new ToolStripMenuItem();
            menuManageUsers = new ToolStripMenuItem();
            menuChangePassword = new ToolStripMenuItem();
            menuHelp = new ToolStripMenuItem();
            menuAbout = new ToolStripMenuItem();
            labelWelcome = new Label();
            menuStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new ToolStripItem[] { menuFile, menuAdministration, menuHelp });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(392, 24);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(48, 20);
            menuFile.Text = "Файл";
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(109, 22);
            menuExit.Text = "Выход";
            // 
            // menuAdministration
            // 
            menuAdministration.DropDownItems.AddRange(new ToolStripItem[] { menuManageUsers, menuChangePassword });
            menuAdministration.Name = "menuAdministration";
            menuAdministration.Size = new Size(134, 20);
            menuAdministration.Text = "Администрирование";
            // 
            // menuManageUsers
            // 
            menuManageUsers.Name = "menuManageUsers";
            menuManageUsers.Size = new Size(234, 22);
            menuManageUsers.Text = "Управление пользователями";
            // 
            // menuChangePassword
            // 
            menuChangePassword.Name = "menuChangePassword";
            menuChangePassword.Size = new Size(234, 22);
            menuChangePassword.Text = "Сменить свой пароль";
            // 
            // menuHelp
            // 
            menuHelp.DropDownItems.AddRange(new ToolStripItem[] { menuAbout });
            menuHelp.Name = "menuHelp";
            menuHelp.Size = new Size(65, 20);
            menuHelp.Text = "Справка";
            // 
            // menuAbout
            // 
            menuAbout.Name = "menuAbout";
            menuAbout.Size = new Size(180, 22);
            menuAbout.Text = "О программе";
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(12, 24);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(38, 15);
            labelWelcome.TabIndex = 1;
            labelWelcome.Text = "label1";
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 333);
            Controls.Add(labelWelcome);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "FormAdmin";
            Text = "FormAdmin";
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuAdministration;
        private ToolStripMenuItem menuManageUsers;
        private ToolStripMenuItem menuChangePassword;
        private ToolStripMenuItem menuHelp;
        private ToolStripMenuItem menuAbout;
        private Label labelWelcome;
    }
}