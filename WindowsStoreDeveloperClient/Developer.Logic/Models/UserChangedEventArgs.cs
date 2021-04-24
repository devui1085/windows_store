using System;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class UserChangedEventArgs : EventArgs
    {
        public UserChangedEventArgs()
        {
        }

        public UserChangedEventArgs(UserInfo newUserInfo, UserInfo oldUserInfo)
        {
            NewUserInfo = newUserInfo;
            OldUserInfo = oldUserInfo;
        }

        public UserInfo NewUserInfo { get; set; }

        public UserInfo OldUserInfo { get; set; }
    }
}
