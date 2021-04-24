using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class AppCategory : BindableBase
    {
        string _title;
        public int Id { get; set; }
        public virtual AppType AppType { get; set; }

        public string Title
        {
            set
            {
                _title = value;
                RaisePropertyChanged();
            }

            get
            {
                return _title;
            }
        }
    }
}
