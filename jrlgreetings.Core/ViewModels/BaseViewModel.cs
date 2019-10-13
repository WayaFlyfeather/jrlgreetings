using jrlgreetings.Core.Models;
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
    public class BaseViewModel : MvxViewModel
    {
        protected readonly IMvxNavigationService navigationService;
        protected readonly IRoomDataService roomDataService;

        protected readonly int roomNo;
        public int RoomNo
        {
            get => roomNo;
        }

        protected double annoyanceFactor = 100.0;
        public double AnnoyanceFactor
        {
            get => annoyanceFactor;
            set
            {
                if (SetProperty(ref annoyanceFactor, value))
                {
                    if (value == 0.0)
                        handleRoomCompletion();                        

                    OnAnnoyanceFactorChanged();
                }
            }
        }

        async void handleRoomCompletion()
        {
            if (await roomDataService.MarkRoomCompleted(this.roomNo))
            {
                Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayClick();

                await RaisePropertyChanged(nameof(Completed));
                await RaisePropertyChanged(nameof(TotalUnCompleted));
                await RaisePropertyChanged(nameof(Title));
            }
        }

        public void NotifyTempleIsCompleted()
        {
            RaisePropertyChanged(nameof(IsTempleCompleted));
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            this.RaiseAllPropertiesChanged();
            this.goNorth_Command?.RaiseCanExecuteChanged();
            this.goEast_Command?.RaiseCanExecuteChanged();
            this.goSouth_Command?.RaiseCanExecuteChanged();
            this.goWest_Command?.RaiseCanExecuteChanged();
            if (IsTempleCompleted)
                AnnoyanceFactor = 0.0;

            this.roomDataService.CurrentLocationChanged += RoomDataService_CurrentLocationChanged;
            this.roomDataService.TempleIsCompleted += RoomDataService_TempleIsCompleted;
        }

        public override void ViewDisappeared()
        {
            this.roomDataService.TempleIsCompleted -= RoomDataService_TempleIsCompleted;
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

        private void RoomDataService_TempleIsCompleted(object sender, EventArgs e)
        {
            this.RaiseAllPropertiesChanged();
        }

        protected virtual void OnAnnoyanceFactorChanged()
        {
        }

        public string Title
        {
            get
            {
                string LeftToComplete = "";
                if (!IsTempleCompleted)
                    LeftToComplete = String.Format($" ({TotalUnCompleted} to complete)");

                if (roomNo < 9)
                    return String.Format($"Room Number {roomNo + 1}{LeftToComplete}");
                else
                    return String.Format($"The Exceptional Room{LeftToComplete}");
            }
        }
        public int TotalUnCompleted => roomDataService.UnCompleted;
        public bool IsTempleCompleted => TotalUnCompleted == 0;
        public bool Completed => thisRoom.Completed;

        public BaseViewModel(int roomNo, IRoomDataService roomDataService, IMvxNavigationService navigationService)        
        {
            this.roomDataService = roomDataService;
            this.navigationService = navigationService;

            this.roomNo = roomNo;
        }

        protected Room thisRoom => roomDataService.GetRoomForRoomNo(roomNo);
        public string RoomDescription => thisRoom.Description;
        public virtual string RoomContentText => thisRoom.ContentText;

        private MvxAsyncCommand goNorth_Command = null;
        public ICommand GoNorth_Command => goNorth_Command ?? (goNorth_Command = new MvxAsyncCommand(roomDataService.GoNorthAsync, () => roomDataService.CanGoNorth));

        private MvxAsyncCommand goWest_Command = null;
        public ICommand GoWest_Command => goWest_Command ?? (goWest_Command = new MvxAsyncCommand(roomDataService.GoWestAsync, () => roomDataService.CanGoWest));

        private MvxAsyncCommand goEast_Command = null;
        public ICommand GoEast_Command => goEast_Command ?? (goEast_Command = new MvxAsyncCommand(roomDataService.GoEastAsync, () => roomDataService.CanGoEast));

        private MvxAsyncCommand goSouth_Command = null;
        public ICommand GoSouth_Command => goSouth_Command ?? (goSouth_Command = new MvxAsyncCommand(roomDataService.GoSouthAsync, () => roomDataService.CanGoSouth));
    }
}
