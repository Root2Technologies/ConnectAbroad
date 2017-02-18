using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
namespace ConnectAbroad
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				RaisePropertyChanged();
			}
		}

		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				isBusy = value;
				RaisePropertyChanged();
			}
		}

		protected void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		string title;
		bool isBusy;

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

	}
}
