using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class AppVersion : BindableBase
    {
        string _version, _description;
        int _downloads;
        long _size;

        public int Id { get; set; }
        public System.DateTime PublishDate { get; set; }
        public int AppId { get; set; }
        public Guid AppGuid { get; set; }

        public int Downloads
        {
            set
            {
                _downloads = value;
                RaisePropertyChanged();
            }

            get
            {
                return _downloads;
            }
        }

        public string Description
        {
            set
            {
                _description = value;
                RaisePropertyChanged();
            }

            get
            {
                return _description;
            }
        }

        public string Version
        {
            set
            {
                _version = value;
                RaisePropertyChanged();
            }

            get
            {
                return _version;
            }
        }

        public long Size
        {
            set
            {
                _size = value;
                RaisePropertyChanged();
            }

            get
            {
                return _size;
            }
        }

        public string SizeString
        {
            get
            {
                return _size.ToSizeString();
            }
        }

        public Version GetVersion()
        {
            return System.Version.Parse(this.Version);
        }
    }
}
