using jrlgreetings.Core.ViewModels;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jrlgreetings.FormsUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExceptionalPage : MvxContentPage
	{
		public ExceptionalPage ()
		{
			InitializeComponent ();
		}

        private void RepoLink_TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/WayaFlyfeather/jrlgreetings"));
        }
    }
}