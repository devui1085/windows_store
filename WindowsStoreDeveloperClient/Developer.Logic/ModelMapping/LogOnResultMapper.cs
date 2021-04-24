using System;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;
using AcountStatus= WindowsStore.Client.Developer.Common.Enum.UserAccountStatus;
namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    internal static class LogOnResultMapper
    {
        public static LogOnResult ToLogOnResult(this AuthenticationResultDataContract authenticationResultDataContract)
        {
            var accountStatus =
                (AcountStatus)
                    Enum.Parse(typeof (AcountStatus), authenticationResultDataContract.UserAccountStatus.ToString());

            var userInfo = new UserInfo
            {
                PrimaryEmail = authenticationResultDataContract.PrimaryEmail,
                Name = authenticationResultDataContract.Name
            };

            return new LogOnResult
            {
                AccountStatus = accountStatus,
                UserInfo = userInfo,
                SignedIn  = authenticationResultDataContract.Authenticated
            };
        }
    }
}
