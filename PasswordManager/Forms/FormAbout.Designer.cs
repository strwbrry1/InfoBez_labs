namespace PasswordManager.Forms
{
    partial class FormAbout
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
            labelTitle = new Label();
            labelAuthor = new Label();
            labelEncryption = new Label();
            labelHash = new Label();
            labelRestrictions = new Label();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(38, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "label1";
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(12, 61);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(38, 15);
            labelAuthor.TabIndex = 1;
            labelAuthor.Text = "label1";
            // 
            // labelEncryption
            // 
            labelEncryption.AutoSize = true;
            labelEncryption.Location = new Point(12, 90);
            labelEncryption.Name = "labelEncryption";
            labelEncryption.Size = new Size(38, 15);
            labelEncryption.TabIndex = 2;
            labelEncryption.Text = "label1";
            // 
            // labelHash
            // 
            labelHash.AutoSize = true;
            labelHash.Location = new Point(12, 120);
            labelHash.Name = "labelHash";
            labelHash.Size = new Size(38, 15);
            labelHash.TabIndex = 3;
            labelHash.Text = "label1";
            // 
            // labelRestrictions
            // 
            labelRestrictions.AutoSize = true;
            labelRestrictions.Location = new Point(12, 149);
            labelRestrictions.Name = "labelRestrictions";
            labelRestrictions.Size = new Size(38, 15);
            labelRestrictions.TabIndex = 4;
            labelRestrictions.Text = "label1";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(217, 241);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 276);
            Controls.Add(buttonClose);
            Controls.Add(labelRestrictions);
            Controls.Add(labelHash);
            Controls.Add(labelEncryption);
            Controls.Add(labelAuthor);
            Controls.Add(labelTitle);
            Name = "FormAbout";
            Text = "FormAbout";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelAuthor;
        private Label labelEncryption;
        private Label labelHash;
        private Label labelRestrictions;
        private Button buttonClose;
    }
}