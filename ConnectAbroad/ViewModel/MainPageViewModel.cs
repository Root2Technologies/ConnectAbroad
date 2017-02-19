using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace ConnectAbroad
{
	public class MainPageViewModel : BaseViewModel
	{
		readonly ITranslationService translateService;
		AuthenticationService authService;
		private ObservableCollection<MessageViewModel> messagesList;

		public ObservableCollection<MessageViewModel> Messages
		{
			get { return messagesList; }
			set { messagesList = value; RaisePropertyChanged(); }
		}

		private string outgoingText;

		public string OutGoingText
		{
			get { return outgoingText; }
			set { outgoingText = value; RaisePropertyChanged(); }
		}

		public ICommand SendCommand { get; set; }


		public MainPageViewModel()
		{
			// Initialize with default values
			authService = new AuthenticationService(Constants.TextTranslatorApiKey);
			translateService = new TranslationService(authService);

			Messages = new ObservableCollection<MessageViewModel>
			{
				new MessageViewModel { Text = "Hi! Do you know where is downtown?", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-25)},
				new MessageViewModel { Text = "市中心非常接近下一個街區", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-24)},
				new MessageViewModel { Text = "Do you have disc in hotel", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
				new MessageViewModel { Text = "\n是。它在4樓", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},
				new MessageViewModel { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},



			};
			OutGoingText = null;
			SendCommand = new Command(() =>
			{
				Messages.Add(new MessageViewModel { Text = OutGoingText, IsIncoming = true, MessagDateTime = DateTime.Now });
				var status = translateService.TranslateText(OutGoingText, LanguageCodes.Hindi).Result;
				Messages.Add(new MessageViewModel { Text = OutGoingText, IsIncoming = false, MessagDateTime = DateTime.Now });
				OutGoingText = null;
			});
		}
		// public List<MessageViewModel> Messages { get; set; } = new List<MessageViewModel>();

	}
}
