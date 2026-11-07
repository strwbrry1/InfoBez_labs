namespace PasswordManager.Forms
{
    partial class FormStartup
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
            textBoxRepeatPassPhrase = new TextBox();
            textBoxPassPhrase = new TextBox();
            buttonConfirm = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(168, 15);
            label2.TabIndex = 13;
            label2.Text = "Повторите парольную фразу";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(152, 15);
            label1.TabIndex = 12;
            label1.Text = "Введите парольную фразу";
            // 
            // textBoxRepeatPassPhrase
            // 
            textBoxRepeatPassPhrase.BackColor = SystemColors.ControlLightLight;
            textBoxRepeatPassPhrase.ForeColor = SystemColors.InfoText;
            textBoxRepeatPassPhrase.Location = new Point(12, 96);
            textBoxRepeatPassPhrase.Name = "textBoxRepeatPassPhrase";
            textBoxRepeatPassPhrase.PasswordChar = '*';
            textBoxRepeatPassPhrase.Size = new Size(291, 23);
            textBoxRepeatPassPhrase.TabIndex = 11;
            // 
            // textBoxPassPhrase
            // 
            textBoxPassPhrase.Location = new Point(12, 34);
            textBoxPassPhrase.Name = "textBoxPassPhrase";
            textBoxPassPhrase.Size = new Size(291, 23);
            textBoxPassPhrase.TabIndex = 10;
            // 
            // buttonConfirm
            // 
            buttonConfirm.BackColor = Color.LightGreen;
            buttonConfirm.Location = new Point(12, 128);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(289, 23);
            buttonConfirm.TabIndex = 14;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // FormStartup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 163);
            Controls.Add(buttonConfirm);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxRepeatPassPhrase);
            Controls.Add(textBoxPassPhrase);
            Name = "FormStartup";
            Text = "FormStartup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox textBoxRepeatPassPhrase;
        private TextBox textBoxPassPhrase;
        private Button buttonConfirm;
    }
}