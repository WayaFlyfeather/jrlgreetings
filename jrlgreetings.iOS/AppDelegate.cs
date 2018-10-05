using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace jrlgreetings.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, jrlgreetings.Core.CoreApp, jrlgreetings.Core.Application>
    {
    }
}
