namespace WindowsStore.Client.Admin.Common.Model.Security
{
    public class AuthenticationResult
    {
        public bool Authenticated { get; set; }
        public string Message { get; set; }
        public Person UserIdentity { get; set; }
    }
}