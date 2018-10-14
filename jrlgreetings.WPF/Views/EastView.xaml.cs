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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jrlgreetings.WPF.Views
{
    /// <summary>
    /// Interaction logic for EastView.xaml
    /// </summary>
    public partial class EastView : MvxWpfView
    {
        public EastView()
        {
            InitializeComponent();
            Loaded += EastView_Loaded;
        }

        private void EastView_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= EastView_Loaded;
            theScrollViewer = FindVisualChildren<ScrollViewer>(this).LastOrDefault();
            if (theScrollViewer != null)
            {
                theScrollViewer.ScrollToVerticalOffset(theScrollViewer.ScrollableHeight / 2.0);
            }
        }

        ScrollViewer theScrollViewer;
        PerspectiveCamera theCamera = null;
        private void DistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (theCamera is null && theScrollViewer != null)
            {
                Viewport3D vp = FindVisualChildren<Viewport3D>(this).FirstOrDefault();
                if (vp != null)
                    theCamera = vp.Camera as PerspectiveCamera;
            }

            if (theCamera is null)
                return;

            theCamera.Position = new Point3D(0.0, 0.0, e.NewValue);
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
