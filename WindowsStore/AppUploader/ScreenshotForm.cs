using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class ScreenshotForm : Form
    {
        WindowsStoreContext context;

        public ScreenshotForm()
        {
            InitializeComponent();
        }

        private async void Screenshoot_Load(object sender, EventArgs e)
        {
            context = new WindowsStoreContext();

            var apps = await Task.Factory.StartNew(() =>
            {
                return context.Apps.ToList();
            });

            appsComboBox.Items.AddRange(apps.ToArray<object>());
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                screenshotsDirectoryTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void registerScreenshotsButton_Click(object sender, EventArgs e)
        {
            if (appsComboBox.SelectedItem == null || string.IsNullOrEmpty(screenshotsDirectoryTextBox.Text))
                MessageBox.Show("Input Validation Error");
            RenameFiles();
            RegisterFiles();
        }

        private void RegisterFiles()
        {
            var files = Directory.EnumerateFiles(screenshotsDirectoryTextBox.Text);
            var app = appsComboBox.SelectedItem as App;

            foreach (var file in files) {
                app.Screenshots.Add(new Screenshot()
                {
                    App = app,
                    FileName = Path.GetFileName(file),
                    Type = Store.Common.Enum.ScreenshotType.Mobile
                });
            }

            context.SaveChanges();
            MessageBox.Show("Screenshots renamed & Registered!");
        }

        private void RenameFiles()
        {
            var files = Directory.EnumerateFiles(screenshotsDirectoryTextBox.Text);
            string newName;
            int counter = 1;
            foreach (var file in files) {
                var extension = Path.GetExtension(file).ToLower();
                if (extension != "jpg" || extension != "png")
                    extension = "jpg";
                do {
                    newName = $"{screenshotsDirectoryTextBox.Text}\\{counter}.{extension}";
                    counter++;
                } while (File.Exists(newName));

                File.Move(file, newName);
            }
        }
    }
}
