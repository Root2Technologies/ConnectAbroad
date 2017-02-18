using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ConnectAbroad.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());
			ConfigureTheming();
			return base.FinishedLaunching(app, options);
		}

		void ConfigureTheming()
		{
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.BarTintColor = Color.FromHex("37474f").ToUIColor();
			UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes { ForegroundColor = UIColor.White };
			UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White }, UIControlState.Normal);
		}
	}
}
