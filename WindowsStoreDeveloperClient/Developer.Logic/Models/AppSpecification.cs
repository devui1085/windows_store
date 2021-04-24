using System;
using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppSpecification : ValidatableBindableBase
    {
        private Guid _guid;
        private string _name;
        private string _description;
        private AppType _appType;
        private int _categoryId;
        private int _price;
        private AppState _state;

        public int AppId { get; set; }
        public Guid Guid
        {
            get { return _guid; }
            set { SetProperty(ref _guid, value); }
        }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public AppType AppType
        {
            get { return _appType; }
            set { SetProperty(ref _appType, value); }
        }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]

        public int CategoryId
        {
            get { return _categoryId; }
            set { SetProperty(ref _categoryId, value); }
        }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]

        public int Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public AppState State { get; set; }

        public int DownloadsCount { get; set; }
        public int CommentsCount { get; set; }

        public int MobileScreenshotsCount { get; set; }
        public int DesktopScreenshotsCount { get; set; }

        public bool IsComplete
            =>!(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || CategoryId == 0);

        public bool HasMobileScreenshot => MobileScreenshotsCount > 0;
        public bool HasDesktopScreenshot => DesktopScreenshotsCount > 0;
    }
}
