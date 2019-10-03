using jrlgreetings.Core.Services;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace jrlgreetings.Core.ViewModels
{
    public class EntranceViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IRoomDataService roomDataService;

        private string templeDevice;
        public string TempleDevice => templeDevice;

        public string Title => "Temple Entrance";
        public string EntranceText =>
            "This is the temple entrance text";

        public EntranceViewModel(string templeDevice, IRoomDataService roomDataService, IMvxNavigationService navigationService)
        {
            this.roomDataService = roomDataService;
            this.navigationService = navigationService;

            this.templeDevice = templeDevice;
        }

        private async Task enterTempleAsync()
        {
            Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayFootsteps();
            await Task.Delay(500);
            await navigationService.Navigate(roomDataService.GetViewModelForRoomNo(0));
        }

        private MvxAsyncCommand enterTemple_Command = null;
        public ICommand EnterTemple_Command => enterTemple_Command ?? (enterTemple_Command = new MvxAsyncCommand(enterTempleAsync));
    }
}
