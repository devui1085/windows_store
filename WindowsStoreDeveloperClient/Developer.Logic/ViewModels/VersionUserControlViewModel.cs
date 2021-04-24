using System;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.Mvvm;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class VersionUserControlViewModel : ViewModelBase, IVersionUserControlViewModel
    {
        #region Constructor

        public VersionUserControlViewModel()
        {
            Major = 1;
        }

        #endregion

        #region Services
        #endregion

        #region Fields

        private int _major;
        private int _minor;
        private int _build;

        #endregion

        #region Properties    

        public int Major
        {
            get { return _major; }
            set { SetProperty(ref _major, value); }
        }

        public int Minor
        {
            get { return _minor; }
            set { SetProperty(ref _minor, value); }
        }

        public int Build
        {
            get { return _build; }
            set { SetProperty(ref _build, value); }
        }


        public Version Version
        {
            get { return new Version(Major, Minor, Build); }
            set
            {
                Major = value.Major;
                Minor = value.Minor;
                Build = value.Build;
            }
        }

        #endregion

        #region Methods
        #endregion

        #region Commands

        #endregion

        #region Actions

        #endregion
    }
}
