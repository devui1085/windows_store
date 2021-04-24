using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Common.Infrastructure;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
  public  class UserCredential : ValidatableBindableBase
    {
        private string _primaryEmail;
        private string _password;

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(RegularExpressionPatterns.Email, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "InvalidEmailErrorMessage")]
        public string PrimaryEmail
        {
            get { return _primaryEmail; }
            set { SetProperty(ref _primaryEmail, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [StringLength(20, MinimumLength = 6, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "PasswordLengthInvalidErrorMessage")]
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}
