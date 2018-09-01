using jrlgreetings.Core.Services;
using MvvmCross.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class NorthWestViewModel : BaseViewModel
    {
        public NorthWestViewModel(IRoomDataService roomDataService, ISoundPlayerService soundPlayerService, IMvxNavigationService navigationService)
            : base(0, roomDataService, soundPlayerService, navigationService)
        {
            annoyanceFactor = 90.0;
        }
    }
}
