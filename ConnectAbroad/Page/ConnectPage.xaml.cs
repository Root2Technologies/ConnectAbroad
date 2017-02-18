using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ConnectAbroad
{
	public partial class ConnectPage : ContentPage
	{
		public ConnectPage()
		{
			InitializeComponent();
			Title = "Connect Abroad";
			BindingContext = new MainPageViewModel();
		}

		private void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			MessagesListView.SelectedItem = null;
		}

		private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			MessagesListView.SelectedItem = null;

		}
	}
}
