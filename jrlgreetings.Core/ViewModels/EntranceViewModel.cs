using jrlgreetings.Core.Services;
using MvvmCross;
using MvvmCross.Base;
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

        public string Title => "Temple Entrance";
        public string EntranceText =>
            "You have arrived at the Temple of Colors!\n" +
            "\n" +
            "You have heard that solving the puzzles of the temple can cure your world - your world, which has lost all colors.\n" +
            "\n" +
            "But first you need to pull levers and overcome several annoyances to read the epic story. And find The Exceptional Room \u2014 which involves doing prohibited calculations!\n" +
            "\n" +
            "Do you dare to enter?";

        public EntranceViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
        {
            this.roomDataService = roomDataService;
            this.navigationService = navigationService;

            checkForReadyTemple();
        }

        async void checkForReadyTemple()
        {
            while (!this.roomDataService.IsReady)
                await Task.Delay(250);

            IsTempleReady = true;
            if (enterTemple_Command != null)
                await Mvx.IoCProvider.Resolve<IMvxMainThreadAsyncDispatcher>().ExecuteOnMainThreadAsync(() => this.RaisePropertyChanged(nameof(IsTempleReady)));
        }

        public bool IsTempleReady { get; private set; } = false;

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
