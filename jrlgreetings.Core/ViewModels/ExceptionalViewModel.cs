using jrlgreetings.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace jrlgreetings.Core.ViewModels
{
    public class ExceptionalViewModel : BaseViewModel
    {
        public ExceptionalViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(9, roomDataService, navigationService)
        {

        }

        private List<bool> roomCompletionList = Enumerable.Repeat<bool>(false, 10).ToList();

        public List<bool> RoomCompletionList
        {
            get => roomCompletionList;
            set => SetProperty(ref roomCompletionList, value);
        }

        protected override void OnAnnoyanceFactorChanged()
        {
            RaisePropertyChanged(nameof(GoToRoom_Command));
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            RoomCompletionList = roomDataService.RoomCompletionInfo.ToList();
        }


        bool canGoToRoom(short roomNo)
        {
            if (roomNo < (100.0 - AnnoyanceFactor) / 10)
                return true;

            return false;
        }

        public ICommand GoToRoom_Command => new MvxAsyncCommand<short>(roomNo => roomDataService.GoToRoomNoAsync(roomNo), roomNo => canGoToRoom(roomNo));
    }
}
