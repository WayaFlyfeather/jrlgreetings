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
using Xamarin.Forms;

namespace jrlgreetings.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected readonly IMvxNavigationService navigationService;
        protected readonly IRoomDataService roomDataService;
//        readonly ISoundPlayerService soundPlayerService;

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
                    if (value == 0.0 && thisRoom.Completed==false)
                    {
                        thisRoom.Completed = true;

                        Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayClick();
                        RaisePropertyChanged(nameof(Completed));
                        RaisePropertyChanged(nameof(TotalUnCompleted));
                        RaisePropertyChanged(nameof(Title));
                        if (IsTempleCompleted)
                        {
                            RaisePropertyChanged(nameof(IsTempleCompleted));
                            navigationService.Navigate(this); // This is hacky
                        }
                    }
                    OnAnnoyanceFactorChanged();
                }
            }
        }

        public void NotifyTempleIsCompleted()
        {
            RaisePropertyChanged(nameof(IsTempleCompleted));
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

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            RaisePropertyChanged(nameof(TotalUnCompleted));
            RaisePropertyChanged(nameof(Title));
            if (IsTempleCompleted)
                AnnoyanceFactor = 0.0;
        }

        protected Room thisRoom => roomDataService.GetRoomForRoomNo(roomNo);
        public string RoomDescription => thisRoom.Description;
        public virtual string RoomContentText => thisRoom.ContentText;
        private bool canGoNorth => roomNo == 9 ? false : roomNo > 2;
        private bool canGoWest => roomNo == 9 ? false : roomNo % 3 > 0;
        private bool canGoEast => roomNo == 9 ? false : roomNo % 3 < 2;
        private bool canGoSouth => roomNo == 9 ? false : roomNo < 6;

        protected async Task goToRoomNoAsync(int destinationRoomNo)
        {
            if (roomNo != destinationRoomNo)
            {
                if (roomNo == 9 || destinationRoomNo == 9)
                    Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayThunder();
                else
                    Mvx.IoCProvider.Resolve<ISoundPlayerService>().PlayFootsteps();

                await Task.Delay(500);
            }
            await navigationService.Navigate(roomDataService.GetViewModelForRoomNo(destinationRoomNo));
        }

        private MvxAsyncCommand goNorth_Command = null;
        public ICommand GoNorth_Command => goNorth_Command ?? (goNorth_Command = new MvxAsyncCommand(() => goToRoomNoAsync(roomNo - 3), () => canGoNorth));

        private MvxAsyncCommand goWest_Command = null;
        public ICommand GoWest_Command => goWest_Command ?? (goWest_Command = new MvxAsyncCommand(() => goToRoomNoAsync(roomNo - 1), () => canGoWest));

        private MvxAsyncCommand goEast_Command = null;
        public ICommand GoEast_Command => goEast_Command ?? (goEast_Command = new MvxAsyncCommand(() => goToRoomNoAsync(roomNo + 1), () => canGoEast));

        private MvxAsyncCommand goSouth_Command = null;
        public ICommand GoSouth_Command => goSouth_Command ?? (goSouth_Command = new MvxAsyncCommand(() => goToRoomNoAsync(roomNo + 3), () => canGoSouth));
    }
}
