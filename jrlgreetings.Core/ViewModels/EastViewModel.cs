using jrlgreetings.Core.Services;
using MvvmCross.Core.Navigation;
using System.Threading;

namespace jrlgreetings.Core.ViewModels
{
    public class EastViewModel : BaseViewModel
    {
        Timer timer;


        private double rotationX;
        public double RotationX
        {
            get => rotationX;
            set => SetProperty(ref rotationX, value % 360.0);
        }

        public EastViewModel(IRoomDataService roomDataService, ISoundPlayerService soundPlayerService, IMvxNavigationService navigationService)
            : base(5, roomDataService, soundPlayerService, navigationService)
        {
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            timer = new Timer(timerTick, null, 10, 25);
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
            if (timer!=null)
            {
                Timer t = timer;
                timer = null;
                t.Dispose();
            }
        }

        void timerTick(object dummy)
        {
            double rx = RotationX;
            if (AnnoyanceFactor < 20 && (rx < 3.0 || rx > 356.0))
            {
                if (rx != 0.0)
                    InvokeOnMainThread(() => { RotationX = 0.0; AnnoyanceFactor = 0.0; });
                return;
            }

            rx += AnnoyanceFactor * .2;
            InvokeOnMainThread(() => RotationX = rx);
        }
    }
}
