using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Common.Infrastructure;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class LegalPerson :ValidatableBindableBase
    {
        private int _id;
        private string _primaryEmail;
        private string _name;
        //private string _password;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(RegularExpressionPatterns.Email, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "InvalidEmailErrorMessage")]
        public string PrimaryEmail
        {
            get { return _primaryEmail; }
            set { SetProperty(ref _primaryEmail, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(RegularExpressionPatterns.Names, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "ErrorRegex")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        //[Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        //[StringLength(20, MinimumLength = 6, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "PasswordLengthInvalidErrorMessage")]
        //public string Password
        //{
        //    get { return _password; }
        //    set { SetProperty(ref _password, value); }
        //}
    }
}
