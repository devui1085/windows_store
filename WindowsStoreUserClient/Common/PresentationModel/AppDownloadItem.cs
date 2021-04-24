using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class AppDownloadItem : BindableBase
    {
        BackgroundTransferStatus _status;
        InstallationStatus _installationStatus;
        DateTime _startDate;
        DateTime _endDate;
        ulong _bytesReceived;
        ulong _totalBytesToReceive;

        public int AppId { get; set; }
        public Guid AppGuid { get; set; }
        public Guid DownloadGuid { get; set; }
        public string AppName { get; set; }
        public DateTime StartDate
        {
            set
            {
                _startDate = value;
                RaisePropertyChanged();
            }
            get
            {
                return _startDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _endDate = value;
                RaisePropertyChanged();
            }
            get
            {
                return _endDate;
            }
        }
        public ulong TotalBytesToReceive
        {
            set
            {
                _totalBytesToReceive = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ProgressPercentage));
            }
            get
            {
                return _totalBytesToReceive;
            }
        }

        public void SetStatus(BackgroundTransferStatus status)
        {
            _status = status;
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(StatusString));
            RaisePropertyChanged(nameof(CanPauseDownload));
            RaisePropertyChanged(nameof(CanResumeDownload));
        }

        public BackgroundTransferStatus GetStatus()
        {
            return _status;
        }

        [XmlIgnore]
        public byte[] Icon64x64Bytes { get; set; }

        [XmlIgnore]
        public ulong BytesReceived
        {
            set
            {
                _bytesReceived = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ProgressPercentage));
                RaisePropertyChanged(nameof(BytesReceivedString));
            }
            get
            {
                return _bytesReceived;
            }
        }

        [XmlIgnore]
        public int ProgressPercentage
        {
            get
            {
                return (TotalBytesToReceive != 0) ? (int)(BytesReceived * 100 / TotalBytesToReceive) : 0;
            }
        }

        [XmlIgnore]
        public string StatusString
        {
            get
            {
                return EnumHelper.LocalizeEnumItem<BackgroundTransferStatus>(_status);
            }
        }

        [XmlIgnore]
        public string BytesReceivedString
        {
            get
            {
                return BytesReceived.ToSizeString(false);
            }
        }

        [XmlIgnore]
        public string TotallBytesToReceiveString
        {
            get
            {
                return TotalBytesToReceive.ToSizeString(false);
            }
        }

        [XmlIgnore]
        public IStorageFile StorageFile { get; set; }

        [XmlIgnore]
        public object Tag { get; set; }

        [XmlIgnore]
        public bool CanPauseDownload
        {
            get
            {
                return _status == BackgroundTransferStatus.Running;
            }
        }

        [XmlIgnore]
        public bool CanResumeDownload
        {
            get
            {
                return
                    _status == BackgroundTransferStatus.PausedByApplication ||
                    _status == BackgroundTransferStatus.Error;
            }
        }

        [XmlIgnore]
        public InstallationStatus InstallationStatus
        {
            get
            {
                return _installationStatus;
            }

            set
            {
                _installationStatus = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(InstallationStatusString));
                RaisePropertyChanged(nameof(ShowInstallingProgress));
            }
        }

        [XmlIgnore]
        public string InstallationStatusString
        {
            get
            {
                string str;
                switch (InstallationStatus)
                {
                    case InstallationStatus.None:
                        str = "";
                        break;
                    case InstallationStatus.Installing:
                        str = "InstallationStatus_Installing".Localize();
                        break;
                    case InstallationStatus.Installed:
                        str = "InstallationStatus_Installed".Localize();
                        break;
                    case InstallationStatus.InstallationFailed:
                        str = "InstallationStatus_InstallationFailed".Localize();
                        break;
                    case InstallationStatus.InstallingAttempt2 :
                        str = "InstallationStatus_InstallingAttempt2".Localize();
                        break;
                    case InstallationStatus.InstallingAttempt3:
                        str = "InstallationStatus_InstallingAttempt3".Localize();
                        break;
                    case InstallationStatus.Waiting:
                        str = "InstallationStatus_Waiting".Localize();
                        break;

                    default:
                        str = "";
                        break;
                }

                return str;
            }
        }

        [XmlIgnore]
        public bool ShowInstallingProgress
        {
            get
            {
                return InstallationStatus == InstallationStatus.Installing;
            }
        }
    }
}
