using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO;
using Store.Common.Enum;

namespace AppUploader
{
    public partial class MainForm : Form
    {
        WindowsStoreContext _ctx;
        public MainForm()
        {
            InitializeComponent();
            _ctx = new WindowsStoreContext();
        }

        private async void uploadAppButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) {
                MessageBox.Show("Form Validation Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileInfo packageInfo = new FileInfo(appArmPackagePathTextBox.Text);
            var paasteelProvider = _ctx.LegalPeople.Single(lp => lp.PrimaryEmail == "provider@paasteel.ir");
            var universalPlatform = _ctx.Platforms.First(p => p.PlatformCategory == PlatformCategory.Windows10Universal);
            var appCategoryId = ((KeyValuePair<int, string>)appCategoryComboBox.SelectedItem).Key;
            var icon128x128 = File.ReadAllBytes(appIcon128x128PathTextBox.Text);
            var icon256x256 = File.ReadAllBytes(appIcon256x256PathTextBox.Text);
            var appTitle = appTitleTextBox.Text;
            var appDescription = appDescriptionTextBox.Text;
            var appVersionDescription = appVersionDescriptionTextBox.Text;
            var appCategory = _ctx.AppCategories.Find(new object[] { appCategoryId });
            var cpuArchitecture = CpuArchitecture.Arm;
            var version = appVersionTextBox.Text;

            try {
                await UploadAppAsync(
                    appTitle,
                    appDescription,
                    appVersionDescription,
                    appCategoryId,
                    packageInfo.Length,
                    icon128x128,
                    icon256x256,
                    cpuArchitecture, version);
            }
            catch {
                MessageBox.Show("Error in submiting app!", "Error");
                return;
            }

            MessageBox.Show("App Uploaded!", "Success");
            ResetForm();
        }

        private async Task UploadAppAsync(string appTitle, string appDescription, string appVersionDescription, int appCategoryId, long packageSize, byte[] icon128x128, byte[] icon256x256, CpuArchitecture cpuArchitecture, string version)
        {
            await Task.Factory.StartNew(() =>
            {
                var paasteelProvider = _ctx.LegalPeople.Single(lp => lp.PrimaryEmail == "provider@paasteel.ir");
                var universalPlatform = _ctx.Platforms.First(p => p.PlatformCategory == PlatformCategory.Windows10Universal);

                var app = new App
                {
                    Guid = Guid.NewGuid(),
                    Developer = paasteelProvider,
                    Name = appTitle,
                    Description = appDescription,
                    Icon128X128 = icon128x128,
                    Icon256X256 = icon256x256,
                    AppCategoryId = appCategoryId,
                    CpuArchitectureFlags = cpuArchitecture,
                    State = AppState.Unpublished
                };
                app.Platforms.Add(universalPlatform);
                app.AppVersions.Add(new AppVersion()
                {
                    Description = appVersionDescription,
                    Downloads = 0,
                    PublishDate = DateTime.Now,
                    Version = version,
                    Size = packageSize
                });
                _ctx.Apps.Add(app);
                _ctx.SaveChanges();
            });
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var appCategories = await LoadAppCategoriesAsync();
            SetAppCategoriesComboBox(appCategories);
        }

        private Task<List<AppCategory>> LoadAppCategoriesAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return _ctx.AppCategories.OrderBy(category => category.AppType).ToList();
            });
        }

        private void SetAppCategoriesComboBox(List<AppCategory> categories)
        {
            categories.ForEach(cat =>
            {
                appCategoryComboBox.Items.Add(
                    new KeyValuePair<int, string>(cat.Id, $"{cat.Title} ({cat.AppType.ToString()})"));
            });
        }

        private bool ValidateForm()
        {
            Version version = new Version();

            if (appTitleTextBox.Text.Trim() == "")
                return false;

            if (appDescriptionTextBox.Text.Trim() == "")
                return false;

            if (!File.Exists(appArmPackagePathTextBox.Text))
                return false;

            if (!File.Exists(appIcon128x128PathTextBox.Text))
                return false;

            if (!File.Exists(appIcon256x256PathTextBox.Text))
                return false;

            if (appCategoryComboBox.SelectedIndex == -1)
                return false;

            if (!Version.TryParse(appVersionTextBox.Text, out version))
                return false;

            if (appVersionDescriptionTextBox.Text.Trim() == "")
                return false;

            return true;
        }

        private void appArmPackageBrowseButton_Click(object sender, EventArgs e)
        {
            if (appPackageFileDialog.ShowDialog() == DialogResult.OK) {
                appArmPackagePathTextBox.Text = appPackageFileDialog.FileName;
            }
        }

        private void appIcon128x128BrowseButton_Click(object sender, EventArgs e)
        {
            if (iconFileDialog.ShowDialog() == DialogResult.OK) {
                appIcon128x128PathTextBox.Text = iconFileDialog.FileName;
            }
        }

        private void appIcon256x256BrowseButton_Click(object sender, EventArgs e)
        {
            if (iconFileDialog.ShowDialog() == DialogResult.OK) {
                appIcon256x256PathTextBox.Text = iconFileDialog.FileName;
            }
        }

        private void ResetForm()
        {
            appArmPackagePathTextBox.Text = "";
            appCategoryComboBox.SelectedIndex = -1;
            appIcon128x128PathTextBox.Text = "";
            appIcon256x256PathTextBox.Text = "";
            appTitleTextBox.Text = "";
            appDescriptionTextBox.Text = "";
            appVersionDescriptionTextBox.Text = "";
            appVersionTextBox.Text = "";
        }
    }
}
