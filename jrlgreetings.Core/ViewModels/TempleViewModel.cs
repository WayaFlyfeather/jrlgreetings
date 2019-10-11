using jrlgreetings.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace jrlgreetings.Core.ViewModels
{
    public class TempleViewModel : MvxViewModel
    {
        protected readonly IMvxNavigationService navigationService;
        protected readonly IRoomDataService roomDataService;

        public TempleViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
        {
            this.roomDataService = roomDataService;
            this.navigationService = navigationService;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            this.roomDataService.CurrentLocationChanged += RoomDataService_CurrentLocationChanged;
        }

        public override void ViewDisappeared()
        {
            this.roomDataService.CurrentLocationChanged -= RoomDataService_CurrentLocationChanged;
            base.ViewDisappeared();
        }

        private void RoomDataService_CurrentLocationChanged(object sender, EventArgs e)
        {
            this.RaiseAllPropertiesChanged();
            this.goNorth_Command?.RaiseCanExecuteChanged();
            this.goEast_Command?.RaiseCanExecuteChanged();
            this.goSouth_Command?.RaiseCanExecuteChanged();
            this.goWest_Command?.RaiseCanExecuteChanged();
        }

        public int TotalUnCompleted => roomDataService.UnCompleted;
        public bool IsTempleCompleted => TotalUnCompleted == 0;

        public IMvxViewModel CurrentRoom => this.roomDataService.CurrentLocationViewModel;

        private MvxAsyncCommand goNorth_Command = null;
        public ICommand GoNorth_Command => goNorth_Command ?? (goNorth_Command = new MvxAsyncCommand(this.roomDataService.GoNorthAsync, () => this.roomDataService.CanGoNorth));

        private MvxAsyncCommand goWest_Command = null;
        public ICommand GoWest_Command => goWest_Command ?? (goWest_Command = new MvxAsyncCommand(this.roomDataService.GoWestAsync, () => this.roomDataService.CanGoWest));

        private MvxAsyncCommand goEast_Command = null;
        public ICommand GoEast_Command => goEast_Command ?? (goEast_Command = new MvxAsyncCommand(this.roomDataService.GoEastAsync, () => this.roomDataService.CanGoEast));

        private MvxAsyncCommand goSouth_Command = null;
        public ICommand GoSouth_Command => goSouth_Command ?? (goSouth_Command = new MvxAsyncCommand(this.roomDataService.GoSouthAsync, () => this.roomDataService.CanGoSouth));
    }
}
