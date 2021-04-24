using System;
using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppVersionSpecification : ValidatableBindableBase
    {
        private string _version;
        private string _description;
        public int AppId { get; set; }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }

        [Required(ErrorMessageResourceType = typeof (ResourceStringsHelper),
            ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public DateTime PublishDate { get; set; }

        public bool IsComplete => !(string.IsNullOrWhiteSpace(Version) || string.IsNullOrWhiteSpace(Description));
    }
}
