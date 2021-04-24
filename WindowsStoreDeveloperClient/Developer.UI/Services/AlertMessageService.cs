using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.Services;

namespace WindowsStore.Client.Developer.UI.Services
{
    public class AlertMessageService : IAlertMessageService
    {
        private static bool _isShowing = false;

        public async Task ShowAsync(string message, string title)
        {
            await ShowAsync(message, title, null);
        }

        public async Task ShowAsync(string message, string title, IEnumerable<DialogCommand> dialogCommands)
        {
            // Only show one dialog at a time.
            if (!_isShowing)
            {
                var messageDialog = new MessageDialog(message, title);
                
                if (dialogCommands != null)
                {
                    var commands = dialogCommands.Select(c => new UICommand(c.Label, (command) => c.Invoked(), c.Id));

                    foreach (var command in commands)
                    {
                        messageDialog.Commands.Add(command);
                    }
                }

                _isShowing = true;
                await messageDialog.ShowAsync();
                _isShowing = false;
            }
        }

        public async Task ShowAsync(string message, string title,params DialogCommand[] dialogCommands)
        {
            // Only show one dialog at a time.
            if (!_isShowing)
            {
                var messageDialog = new MessageDialog(message);
              
                if (!string.IsNullOrEmpty(title))
                    messageDialog.Title = title;
                
                if (dialogCommands != null)
                {
                    var commands = dialogCommands.Select(c => new UICommand(c.Label, (command) => c.Invoked(), c.Id));

                    foreach (var command in commands)
                    {
                        messageDialog.Commands.Add(command);
                    }
                }

                _isShowing = true;
                await messageDialog.ShowAsync();
                _isShowing = false;
            }
        }
    }
}
