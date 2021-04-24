using WindowsStore.Client.User.Common.Enum;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class AuthenticationResult
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public Person Person { get; set; }
        public bool IsNaturalPerson { get; set; }
        public UserAccountStatus UserAccountStatus { get; set; }

    }
}