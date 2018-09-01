using jrlgreetings.Core.Services;
using MvvmCross.Core.Navigation;

namespace jrlgreetings.Core.ViewModels
{
    public class SouthViewModel : BaseViewModel
    {
        public SouthViewModel(IRoomDataService roomDataService, ISoundPlayerService soundPlayerService, IMvxNavigationService navigationService)
            : base(7, roomDataService, soundPlayerService, navigationService)
        {
        }
    }
}
