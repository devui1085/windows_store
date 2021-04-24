﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Blend.SampleData.SampleDataSource
{
	using System; 
	using System.ComponentModel;

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleDataSource { }
#else

	public class SampleDataSource : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public SampleDataSource()
		{
			try
			{
				Uri resourceUri = new Uri("ms-appx:/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
				Windows.UI.Xaml.Application.LoadComponent(this, resourceUri);
			}
			catch
			{
			}
		}

		private NaturalUsers _NaturalUsers = new NaturalUsers();

		public NaturalUsers NaturalUsers
		{
			get
			{
				return this._NaturalUsers;
			}
		}
	}

	public class NaturalUsersItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private string _FirstName = string.Empty;

		public string FirstName
		{
			get
			{
				return this._FirstName;
			}

			set
			{
				if (this._FirstName != value)
				{
					this._FirstName = value;
					this.OnPropertyChanged("FirstName");
				}
			}
		}

		private string _LastName = string.Empty;

		public string LastName
		{
			get
			{
				return this._LastName;
			}

			set
			{
				if (this._LastName != value)
				{
					this._LastName = value;
					this.OnPropertyChanged("LastName");
				}
			}
		}

		private string _PrimaryEmail = string.Empty;

		public string PrimaryEmail
		{
			get
			{
				return this._PrimaryEmail;
			}

			set
			{
				if (this._PrimaryEmail != value)
				{
					this._PrimaryEmail = value;
					this.OnPropertyChanged("PrimaryEmail");
				}
			}
		}
	}

	public class NaturalUsers : System.Collections.ObjectModel.ObservableCollection<NaturalUsersItem>
	{ 
	}
#endif
}
