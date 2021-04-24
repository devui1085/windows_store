using WindowsStore.Client.Developer.Logic.Services;

namespace WindowsStore.Client.Developer.Logic
{
    public static class DialogCommands
    {
        public static DialogCommand CloseDialogCommand => new DialogCommand() { Label = ResourceStringsHelper.Close , Invoked = delegate { } };
    }
}
