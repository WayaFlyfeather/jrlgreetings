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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jrlgreetings.WPF.Views
{
    /// <summary>
    /// Interaction logic for BaseRoomControl.xaml
    /// </summary>

    [ContentProperty("RoomChallengeContent")]
    public partial class BaseRoomControl : UserControl
    {
        public object RoomChallengeContent
        {
            get { return (object)GetValue(RoomChallengeContentProperty); }
            set { SetValue(RoomChallengeContentProperty, value); }
        }

        public static readonly DependencyProperty RoomChallengeContentProperty =
            DependencyProperty.Register("RoomChallengeContent", typeof(object), typeof(BaseRoomControl),
              new PropertyMetadata(null));

        public BaseRoomControl()
        {
            InitializeComponent();
        }
    }
}
