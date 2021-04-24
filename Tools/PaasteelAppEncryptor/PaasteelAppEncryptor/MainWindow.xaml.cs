using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace PaasteelAppEncryptor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                UriTextBox.Text = dialog.SelectedPath;
            }

            EncryptAppsInSelectedPath();
        }

        private void EncryptAppsInSelectedPath()
        {
            // find all appx files
            string directoryPath = UriTextBox.Text;
            var allDirectoryFilePaths = Directory.GetFiles(directoryPath, "*.appx", SearchOption.AllDirectories);

            //
            foreach (var filePath in allDirectoryFilePaths)
            {
                //foreach file generate a key for encryption 
                var fileGuidString = Directory.GetParent(filePath).Name;
                var encryptionKey =FileEncryptor.GenerateEncryptionKey(fileGuidString.ToLower());

                // encrypt and save file with generatedKey
                OutputRichTextBox.AppendText($"Start encrypting file {fileGuidString} ...");
                FileEncryptor.EncryptFile(filePath, encryptionKey);
                OutputRichTextBox.AppendText($"file {fileGuidString} encrypted" + Environment.NewLine);
            }
        }
    }
}
