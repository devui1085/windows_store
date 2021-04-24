
using System;
using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppInfo: ValidatableBindableBase
    {
        private string _name;
        private string _title;
        private string _description;
        private AppType _appType;
        private int _appCategoryId;
        private decimal _appPrice;
        
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public AppType AppType
        {
            get { return _appType; }
            set { SetProperty(ref _appType, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public int AppCategoryId
        {
            get { return _appCategoryId; }
            set { SetProperty(ref _appCategoryId, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public decimal AppPrice
        {
            get { return _appPrice; }
            set { SetProperty(ref _appPrice, value); }
        }
    }
}
