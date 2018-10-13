using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jrlgreetings.WPF.Views
{
    /// <summary>
    /// Interaction logic for ExceptionalView.xaml
    /// </summary>
    public partial class ExceptionalView : MvxWpfView
    {
        public ExceptionalView()
        {
            InitializeComponent();
        }

        private void GitHubLinkClicked(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://devconnect.xamarin.com/profile/861");
        }
    }
}
