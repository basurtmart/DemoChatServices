using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Chat.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client_Chat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
		public ChatPage ()
		{
			InitializeComponent ();
		}

	    private void ChatPage_OnAppearing(object sender, EventArgs e)
	    {
	        BindingContext = new VMChat();
	    }
	}
}