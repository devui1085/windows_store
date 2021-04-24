using System;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface ISignInViewModel
    { 
        void Open(Action successAction);
        void CheckUserSavedCredential(string defualtPage);
        //void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewState);

        //void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewState, bool suspending);
    }
}
