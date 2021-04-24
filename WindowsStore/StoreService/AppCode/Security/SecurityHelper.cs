using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Common.InternalException;

namespace Store.StoreService.AppCode.Security
{
    public class SecurityHelper
    {
        public static void ValidateUserRequest(string primaryEmail)
        {
            if (!Principal.CurrentUser.UserName.Equals(primaryEmail))
                throw new GeneralInternalException(Store.Common.Enum.FaultCode.NotAuthenticated);
        }

        public static void ValidateUserRequest(int userId)
        {
            if (Principal.CurrentUser.UserId != userId)
                throw new GeneralInternalException(Store.Common.Enum.FaultCode.NotAuthenticated);
        }


    }
}