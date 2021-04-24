using WindowsStore.Client.Developer.Common.Enum;

namespace WindowsStore.Client.Developer.Logic.Models
{
  public  class LogOnResult
    {
        public UserInfo UserInfo { get; set; }

        public UserAccountStatus AccountStatus { get; set; }

        public bool SignedIn { get; set; }
    }
}
