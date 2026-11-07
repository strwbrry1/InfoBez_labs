namespace PasswordManager.Forms
{
    partial class FormUserManagement
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
            dataGridViewUsers = new DataGridView();
            colUsername = new DataGridViewTextBoxColumn();
            colBlocked = new DataGridViewTextBoxColumn();
            colRestrictions = new DataGridViewTextBoxColumn();
            colMinLength = new DataGridViewTextBoxColumn();
            colExpiration = new DataGridViewTextBoxColumn();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonAddUser = new Button();
            buttonToggleBlock = new Button();
            buttonEditSettings = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Columns.AddRange(new DataGridViewColumn[] { colUsername, colBlocked, colRestrictions, colMinLength, colExpiration });
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(0, 0);
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(800, 450);
            dataGridViewUsers.TabIndex = 0;
            // 
            // colUsername
            // 
            colUsername.HeaderText = "Пользователь";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colBlocked
            // 
            colBlocked.HeaderText = "Заблокирован";
            colBlocked.Name = "colBlocked";
            colBlocked.ReadOnly = true;
            // 
            // colRestrictions
            // 
            colRestrictions.HeaderText = "Ограничения";
            colRestrictions.Name = "colRestrictions";
            colRestrictions.ReadOnly = true;
            // 
            // colMinLength
            // 
            colMinLength.HeaderText = "Мин. длина";
            colMinLength.Name = "colMinLength";
            colMinLength.ReadOnly = true;
            // 
            // colExpiration
            // 
            colExpiration.HeaderText = "Срок (мес.)";
            colExpiration.Name = "colExpiration";
            colExpiration.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonAddUser);
            flowLayoutPanel1.Controls.Add(buttonToggleBlock);
            flowLayoutPanel1.Controls.Add(buttonEditSettings);
            flowLayoutPanel1.Controls.Add(buttonClose);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 411);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 39);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonAddUser
            // 
            buttonAddUser.Location = new Point(3, 3);
            buttonAddUser.Name = "buttonAddUser";
            buttonAddUser.Size = new Size(91, 31);
            buttonAddUser.TabIndex = 0;
            buttonAddUser.Text = "Добавить";
            buttonAddUser.UseVisualStyleBackColor = true;
            // 
            // buttonToggleBlock
            // 
            buttonToggleBlock.Location = new Point(100, 3);
            buttonToggleBlock.Name = "buttonToggleBlock";
            buttonToggleBlock.Size = new Size(96, 31);
            buttonToggleBlock.TabIndex = 1;
            buttonToggleBlock.Text = "Блокировать";
            buttonToggleBlock.UseVisualStyleBackColor = true;
            // 
            // buttonEditSettings
            // 
            buttonEditSettings.Location = new Point(202, 3);
            buttonEditSettings.Name = "buttonEditSettings";
            buttonEditSettings.Size = new Size(84, 31);
            buttonEditSettings.TabIndex = 2;
            buttonEditSettings.Text = "Параметры";
            buttonEditSettings.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(292, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(79, 31);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormUserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dataGridViewUsers);
            Name = "FormUserManagement";
            Text = "FormUserManagement";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewUsers;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colBlocked;
        private DataGridViewTextBoxColumn colRestrictions;
        private DataGridViewTextBoxColumn colMinLength;
        private DataGridViewTextBoxColumn colExpiration;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonAddUser;
        private Button buttonToggleBlock;
        private Button buttonEditSettings;
        private Button buttonClose;
    }
}