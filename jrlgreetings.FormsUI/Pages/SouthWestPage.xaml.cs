using MvvmCross.Forms.Core;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jrlgreetings.FormsUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SouthWestPage : MvxContentPage
	{
		public SouthWestPage ()
		{
			InitializeComponent ();
            certImageButton.Source = ImageSource.FromResource("jrlgreetings.FormsUI.xamarin_mobile_developer.png", GetType().Assembly);
        }

        private void certImageButton_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://greetingsfromjrl.azurewebsites.net/jrlxamcert.pdf"));
        }
    }
}