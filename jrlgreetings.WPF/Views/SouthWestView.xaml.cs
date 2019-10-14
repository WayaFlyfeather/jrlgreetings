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
    /// Interaction logic for SouthWestView.xaml
    /// </summary>
    public partial class SouthWestView : MvxWpfView
    {
        public SouthWestView()
        {
            InitializeComponent();
        }

        private void XamarinImageClicked(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://greetingsfromjrl.azurewebsites.net/jrlxamcert.pdf");
        }
    }
}
