using jrlgreetings.Core.Services;
using MvvmCross.Navigation;

namespace jrlgreetings.Core.ViewModels
{
    public class SouthViewModel : BaseViewModel
    {
        public SouthViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(7, roomDataService, navigationService)
        {
        }
    }
}
