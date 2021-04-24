using System;
using System.Collections;
using System.ComponentModel;

namespace Framework.MVVM
{
    public abstract class _DomainObjectTemp : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region
        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public bool HasErrors { get; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion
    }
}
