using System;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using WindowsStore.Client.Developer.Logic.ServiceInterface;

namespace WindowsStore.Client.Developer.UI.Services
{
    // Documentation on working with tiles can be found at http://go.microsoft.com/fwlink/?LinkID=288821&clcid=0x409
    public class SecondaryTileService : ISecondaryTileService
    {
        private readonly Uri _squareLogoUri = new Uri("ms-appx:///Assets/Logo.png");
        private readonly Uri _wideLogoUri = new Uri("ms-appx:///Assets/WideLogo.scale-100.png");

        public bool SecondaryTileExists(string tileId)
        {
            return SecondaryTile.Exists(tileId);
        }

        public async Task<bool> PinSquareSecondaryTile(string tileId, string displayName, string arguments)
        {
            if (!SecondaryTileExists(tileId))
            {
                var secondaryTile = new SecondaryTile(tileId, displayName, arguments, _squareLogoUri, TileSize.Square150x150);
                bool isPinned = await secondaryTile.RequestCreateAsync();
                
                return isPinned;
            }

            return true;
        }

        public async Task<bool> PinWideSecondaryTile(string tileId, string displayName, string arguments)
        {
            if (!SecondaryTileExists(tileId))
            {
                var secondaryTile = new SecondaryTile(tileId, displayName, arguments, _squareLogoUri, TileSize.Wide310x150);
                secondaryTile.VisualElements.ShowNameOnWide310x150Logo = true;
                secondaryTile.VisualElements.Wide310x150Logo = _wideLogoUri;
                bool isPinned = await secondaryTile.RequestCreateAsync();
                return isPinned;
            }

            return true;
        }

        public async Task<bool> UnpinTile(string tileId)
        {
            if (SecondaryTileExists(tileId))
            {
                var secondaryTile = new SecondaryTile(tileId);
                bool isUnpinned = await secondaryTile.RequestDeleteAsync();
                return isUnpinned;
            }

            return true;
        }

        public void ActivateTileNotifications(string tileId, Uri tileContentUri, PeriodicUpdateRecurrence recurrence)
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForSecondaryTile(tileId);
            tileUpdater.StartPeriodicUpdate(tileContentUri, recurrence);
        }
    }
}
