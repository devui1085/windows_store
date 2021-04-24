namespace AppUploader
{
    partial class MainForm
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
            this.iconFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.appPackageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.appCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.appVersionTextBox = new System.Windows.Forms.TextBox();
            this.appIcon256x256PathTextBox = new System.Windows.Forms.TextBox();
            this.appIcon128x128PathTextBox = new System.Windows.Forms.TextBox();
            this.appArmPackagePathTextBox = new System.Windows.Forms.TextBox();
            this.appVersionDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.appDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.appTitleTextBox = new System.Windows.Forms.TextBox();
            this.appIcon256x256BrowseButton = new System.Windows.Forms.Button();
            this.appIcon128x128BrowseButton = new System.Windows.Forms.Button();
            this.appArmPackageBrowseButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadAppButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconFileDialog
            // 
            this.iconFileDialog.Filter = "*.png|*.png";
            // 
            // appPackageFileDialog
            // 
            this.appPackageFileDialog.Filter = "*.appx|*.appx";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 607);
            this.tabControl1.TabIndex = 57;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.uploadAppButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upload App";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.appCategoryComboBox);
            this.panel1.Controls.Add(this.appVersionTextBox);
            this.panel1.Controls.Add(this.appIcon256x256PathTextBox);
            this.panel1.Controls.Add(this.appIcon128x128PathTextBox);
            this.panel1.Controls.Add(this.appArmPackagePathTextBox);
            this.panel1.Controls.Add(this.appVersionDescriptionTextBox);
            this.panel1.Controls.Add(this.appDescriptionTextBox);
            this.panel1.Controls.Add(this.appTitleTextBox);
            this.panel1.Controls.Add(this.appIcon256x256BrowseButton);
            this.panel1.Controls.Add(this.appIcon128x128BrowseButton);
            this.panel1.Controls.Add(this.appArmPackageBrowseButton);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 499);
            this.panel1.TabIndex = 77;
            // 
            // appCategoryComboBox
            // 
            this.appCategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appCategoryComboBox.DisplayMember = "Value";
            this.appCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appCategoryComboBox.FormattingEnabled = true;
            this.appCategoryComboBox.Location = new System.Drawing.Point(184, 279);
            this.appCategoryComboBox.Name = "appCategoryComboBox";
            this.appCategoryComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.appCategoryComboBox.Size = new System.Drawing.Size(486, 23);
            this.appCategoryComboBox.TabIndex = 95;
            this.appCategoryComboBox.ValueMember = "Key";
            // 
            // appVersionTextBox
            // 
            this.appVersionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appVersionTextBox.Location = new System.Drawing.Point(184, 308);
            this.appVersionTextBox.Name = "appVersionTextBox";
            this.appVersionTextBox.Size = new System.Drawing.Size(486, 21);
            this.appVersionTextBox.TabIndex = 94;
            // 
            // appIcon256x256PathTextBox
            // 
            this.appIcon256x256PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appIcon256x256PathTextBox.Location = new System.Drawing.Point(184, 252);
            this.appIcon256x256PathTextBox.Name = "appIcon256x256PathTextBox";
            this.appIcon256x256PathTextBox.Size = new System.Drawing.Size(486, 21);
            this.appIcon256x256PathTextBox.TabIndex = 93;
            // 
            // appIcon128x128PathTextBox
            // 
            this.appIcon128x128PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appIcon128x128PathTextBox.Location = new System.Drawing.Point(184, 225);
            this.appIcon128x128PathTextBox.Name = "appIcon128x128PathTextBox";
            this.appIcon128x128PathTextBox.Size = new System.Drawing.Size(486, 21);
            this.appIcon128x128PathTextBox.TabIndex = 92;
            // 
            // appArmPackagePathTextBox
            // 
            this.appArmPackagePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appArmPackagePathTextBox.Location = new System.Drawing.Point(184, 198);
            this.appArmPackagePathTextBox.Name = "appArmPackagePathTextBox";
            this.appArmPackagePathTextBox.Size = new System.Drawing.Size(486, 21);
            this.appArmPackagePathTextBox.TabIndex = 91;
            // 
            // appVersionDescriptionTextBox
            // 
            this.appVersionDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appVersionDescriptionTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appVersionDescriptionTextBox.Location = new System.Drawing.Point(184, 335);
            this.appVersionDescriptionTextBox.Multiline = true;
            this.appVersionDescriptionTextBox.Name = "appVersionDescriptionTextBox";
            this.appVersionDescriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.appVersionDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.appVersionDescriptionTextBox.Size = new System.Drawing.Size(601, 146);
            this.appVersionDescriptionTextBox.TabIndex = 90;
            // 
            // appDescriptionTextBox
            // 
            this.appDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appDescriptionTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.appDescriptionTextBox.Location = new System.Drawing.Point(183, 32);
            this.appDescriptionTextBox.Multiline = true;
            this.appDescriptionTextBox.Name = "appDescriptionTextBox";
            this.appDescriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.appDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.appDescriptionTextBox.Size = new System.Drawing.Size(601, 157);
            this.appDescriptionTextBox.TabIndex = 89;
            // 
            // appTitleTextBox
            // 
            this.appTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appTitleTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.appTitleTextBox.Location = new System.Drawing.Point(183, 5);
            this.appTitleTextBox.Name = "appTitleTextBox";
            this.appTitleTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.appTitleTextBox.Size = new System.Drawing.Size(601, 23);
            this.appTitleTextBox.TabIndex = 88;
            // 
            // appIcon256x256BrowseButton
            // 
            this.appIcon256x256BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appIcon256x256BrowseButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.appIcon256x256BrowseButton.Location = new System.Drawing.Point(676, 250);
            this.appIcon256x256BrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.appIcon256x256BrowseButton.Name = "appIcon256x256BrowseButton";
            this.appIcon256x256BrowseButton.Size = new System.Drawing.Size(108, 26);
            this.appIcon256x256BrowseButton.TabIndex = 87;
            this.appIcon256x256BrowseButton.Text = "Browse";
            this.appIcon256x256BrowseButton.UseVisualStyleBackColor = true;
            this.appIcon256x256BrowseButton.Click += new System.EventHandler(this.appIcon256x256BrowseButton_Click);
            // 
            // appIcon128x128BrowseButton
            // 
            this.appIcon128x128BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appIcon128x128BrowseButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.appIcon128x128BrowseButton.Location = new System.Drawing.Point(676, 223);
            this.appIcon128x128BrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.appIcon128x128BrowseButton.Name = "appIcon128x128BrowseButton";
            this.appIcon128x128BrowseButton.Size = new System.Drawing.Size(108, 26);
            this.appIcon128x128BrowseButton.TabIndex = 86;
            this.appIcon128x128BrowseButton.Text = "Browse";
            this.appIcon128x128BrowseButton.UseVisualStyleBackColor = true;
            this.appIcon128x128BrowseButton.Click += new System.EventHandler(this.appIcon128x128BrowseButton_Click);
            // 
            // appArmPackageBrowseButton
            // 
            this.appArmPackageBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appArmPackageBrowseButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.appArmPackageBrowseButton.Location = new System.Drawing.Point(676, 196);
            this.appArmPackageBrowseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.appArmPackageBrowseButton.Name = "appArmPackageBrowseButton";
            this.appArmPackageBrowseButton.Size = new System.Drawing.Size(108, 26);
            this.appArmPackageBrowseButton.TabIndex = 85;
            this.appArmPackageBrowseButton.Text = "Browse";
            this.appArmPackageBrowseButton.UseVisualStyleBackColor = true;
            this.appArmPackageBrowseButton.Click += new System.EventHandler(this.appArmPackageBrowseButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 77;
            this.label7.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 15);
            this.label6.TabIndex = 78;
            this.label6.Text = "App Version Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 79;
            this.label3.Text = "Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 80;
            this.label4.Text = "ARM Package";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 81;
            this.label10.Text = "Icon 256 * 256";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 82;
            this.label5.Text = "Icon 128 * 128";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 84;
            this.label8.Text = "App Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 83;
            this.label1.Text = "App Title";
            // 
            // uploadAppButton
            // 
            this.uploadAppButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uploadAppButton.Location = new System.Drawing.Point(19, 537);
            this.uploadAppButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uploadAppButton.Name = "uploadAppButton";
            this.uploadAppButton.Size = new System.Drawing.Size(126, 33);
            this.uploadAppButton.TabIndex = 65;
            this.uploadAppButton.Text = "Upload App";
            this.uploadAppButton.UseVisualStyleBackColor = true;
            this.uploadAppButton.Click += new System.EventHandler(this.uploadAppButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 607);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(500, 550);
            this.Name = "MainForm";
            this.Text = "Paasteel Admin Control Panel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog iconFileDialog;
        private System.Windows.Forms.OpenFileDialog appPackageFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button uploadAppButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button appArmPackageBrowseButton;
        private System.Windows.Forms.Button appIcon128x128BrowseButton;
        private System.Windows.Forms.Button appIcon256x256BrowseButton;
        private System.Windows.Forms.TextBox appTitleTextBox;
        private System.Windows.Forms.TextBox appDescriptionTextBox;
        private System.Windows.Forms.TextBox appVersionDescriptionTextBox;
        private System.Windows.Forms.TextBox appArmPackagePathTextBox;
        private System.Windows.Forms.TextBox appIcon128x128PathTextBox;
        private System.Windows.Forms.TextBox appIcon256x256PathTextBox;
        private System.Windows.Forms.TextBox appVersionTextBox;
        private System.Windows.Forms.ComboBox appCategoryComboBox;
    }
}