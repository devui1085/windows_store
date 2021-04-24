using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Common.Enum;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class User : ValidatableBindableBase
    {
        private const string NamesRegexPattern = @"\A\p{L}+([\p{Zs}\-][\p{L}]+)*\z";

        private string _id;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _email;
        private Sexuality _sexuality;


        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
            
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(NamesRegexPattern, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RegexErrorMessage")]
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }


        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(NamesRegexPattern, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RegexErrorMessage")]
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper),ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        public Sexuality Sexuality
        {
            get { return _sexuality; }
            set { SetProperty(ref _sexuality, value); }
        }
    }
}
