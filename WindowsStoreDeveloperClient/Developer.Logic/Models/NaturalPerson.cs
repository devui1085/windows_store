using System.ComponentModel.DataAnnotations;
using WindowsStore.Client.Developer.Common.Infrastructure;
using WindowsStore.Client.Developer.Logic.Services;
using Prism.Windows.Validation;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class NaturalPerson : ValidatableBindableBase
    {
        private int _id;
        private string _firstName;
        private string _lastName;
       


        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(RegularExpressionPatterns.Email, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "InvalidEmailErrorMessage")]
        public string PrimaryEmail { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(RegularExpressionPatterns.Names, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "ErrorRegex")]
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        [Required(ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "RequiredErrorMessage")]
        [RegularExpression(RegularExpressionPatterns.Names, ErrorMessageResourceType = typeof(ResourceStringsHelper), ErrorMessageResourceName = "ErrorRegex")]
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
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
