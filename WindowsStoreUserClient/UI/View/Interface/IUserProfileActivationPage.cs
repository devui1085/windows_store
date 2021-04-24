using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.User.UI.View.Interface
{
    public interface IUserProfileActivationPage
    {
        Task ShowInvalidCodeMessageAsync();
        Task ShowErrorOcurredMessageAsync();
        Task ShowActivationCodeSentMessageAsync();
        Task ShowResendingCodeFailedMessageAsync();

        void NavigateToCatalogPage();
    }
}
