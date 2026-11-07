namespace PasswordManager.Forms
{
    partial class FormUserSettings
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
            numericExpiration = new NumericUpDown();
            numericMinLength = new NumericUpDown();
            checkBoxRestrictions = new CheckBox();
            label2 = new Label();
            buttonCancel = new Button();
            buttonSave = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericExpiration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMinLength).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 114);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 27;
            label3.Text = "Срок действия (мес.)";
            // 
            // numericExpiration
            // 
            numericExpiration.Location = new Point(169, 112);
            numericExpiration.Maximum = new decimal(new int[] { 1200, 0, 0, 0 });
            numericExpiration.Name = "numericExpiration";
            numericExpiration.Size = new Size(98, 23);
            numericExpiration.TabIndex = 26;
            // 
            // numericMinLength
            // 
            numericMinLength.Location = new Point(169, 63);
            numericMinLength.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            numericMinLength.Name = "numericMinLength";
            numericMinLength.Size = new Size(98, 23);
            numericMinLength.TabIndex = 25;
            // 
            // checkBoxRestrictions
            // 
            checkBoxRestrictions.AutoSize = true;
            checkBoxRestrictions.Location = new Point(16, 27);
            checkBoxRestrictions.Name = "checkBoxRestrictions";
            checkBoxRestrictions.Size = new Size(141, 19);
            checkBoxRestrictions.TabIndex = 24;
            checkBoxRestrictions.Text = "ограничения пароля";
            checkBoxRestrictions.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 65);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 23;
            label2.Text = "Мин. длина пароля";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Coral;
            buttonCancel.Location = new Point(228, 150);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 22;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.LightGreen;
            buttonSave.Location = new Point(12, 150);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 21;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 28;
            label1.Text = "Пользователь";
            // 
            // FormUserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 198);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(numericExpiration);
            Controls.Add(numericMinLength);
            Controls.Add(checkBoxRestrictions);
            Controls.Add(label2);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Name = "FormUserSettings";
            Text = "FormUserSettings";
            ((System.ComponentModel.ISupportInitialize)numericExpiration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMinLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private NumericUpDown numericExpiration;
        private NumericUpDown numericMinLength;
        private CheckBox checkBoxRestrictions;
        private Label label2;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label1;
    }
}