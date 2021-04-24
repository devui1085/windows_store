namespace AdminPanel
{
    partial class ScreenshotForm
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
            if (disposing && (components != null)) {
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
            this.label1 = new System.Windows.Forms.Label();
            this.appsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.screenshotsDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.registerScreenshotsButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "App";
            // 
            // appsComboBox
            // 
            this.appsComboBox.DisplayMember = "Name";
            this.appsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.appsComboBox.FormattingEnabled = true;
            this.appsComboBox.Location = new System.Drawing.Point(129, 23);
            this.appsComboBox.Name = "appsComboBox";
            this.appsComboBox.Size = new System.Drawing.Size(481, 24);
            this.appsComboBox.TabIndex = 1;
            this.appsComboBox.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Screenshots Directory";
            // 
            // screenshotsDirectoryTextBox
            // 
            this.screenshotsDirectoryTextBox.Enabled = false;
            this.screenshotsDirectoryTextBox.Location = new System.Drawing.Point(129, 64);
            this.screenshotsDirectoryTextBox.Name = "screenshotsDirectoryTextBox";
            this.screenshotsDirectoryTextBox.Size = new System.Drawing.Size(369, 20);
            this.screenshotsDirectoryTextBox.TabIndex = 2;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(504, 62);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(106, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // registerScreenshotsButton
            // 
            this.registerScreenshotsButton.Location = new System.Drawing.Point(15, 146);
            this.registerScreenshotsButton.Name = "registerScreenshotsButton";
            this.registerScreenshotsButton.Size = new System.Drawing.Size(165, 39);
            this.registerScreenshotsButton.TabIndex = 4;
            this.registerScreenshotsButton.Text = "Register Screenshots";
            this.registerScreenshotsButton.UseVisualStyleBackColor = true;
            this.registerScreenshotsButton.Click += new System.EventHandler(this.registerScreenshotsButton_Click);
            // 
            // ScreenshotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 197);
            this.Controls.Add(this.registerScreenshotsButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.screenshotsDirectoryTextBox);
            this.Controls.Add(this.appsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ScreenshotForm";
            this.Text = "Screenshoot";
            this.Load += new System.EventHandler(this.Screenshoot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox appsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox screenshotsDirectoryTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button registerScreenshotsButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}