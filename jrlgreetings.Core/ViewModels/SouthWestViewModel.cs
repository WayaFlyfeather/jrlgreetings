using jrlgreetings.Core.Services;
using MvvmCross.Navigation;

namespace jrlgreetings.Core.ViewModels
{
    public class SouthWestViewModel : BaseViewModel
    {
        public SouthWestViewModel(IRoomDataService roomDataService, ISoundPlayerService soundPlayerService, IMvxNavigationService navigationService)
            : base(6, roomDataService, soundPlayerService, navigationService)
        {
        }
    }
}
