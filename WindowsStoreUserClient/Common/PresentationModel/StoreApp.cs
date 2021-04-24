using System;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class StoreApp : BindableBase
    {
        string _name, _description, _developerName;
        BitmapImage _icon128x128, _backgroundImage;
        int _price;

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public int Price
        {
            set
            {
                _price = value;
                RaisePropertyChanged();
            }

            get
            {
                return _price;
            }
        }

        public string PriceString
        {
            get
            {
                return _price == 0 ?
                    "Free".Localize() :
                    string.Format("{0} {1}", _price, "Toman".Localize());
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }
        public AppCategory AppCategory { get; set; }
        public byte[] Icon128x128Bytes { get; set; }
        public BitmapImage Icon128x128 { get; set; }
        public byte[] Icon256x256Bytes { get; set; }
        public BitmapImage Icon256X256 { get; set; }
        public string DeveloperName
        {
            get
            {
                return _developerName;
            }

            set
            {
                _developerName = value;
                RaisePropertyChanged();
            }
        }
        public int DeveloperId { get; set; }
        public AppVersion LatestVersion { get; set; }
        public int NumberOfMobileScreenshots { get; set; }
        public BitmapImage BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }

            set
            {
                _backgroundImage = value;
                RaisePropertyChanged();
            }
        }

        public StoreApp()
        {
        }
    }
}
