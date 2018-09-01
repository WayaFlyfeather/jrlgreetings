using jrlgreetings.Core.Services;
using MvvmCross.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class NorthViewModel : BaseViewModel
    {
        public NorthViewModel(IRoomDataService roomDataService, ISoundPlayerService soundPlayerService, IMvxNavigationService navigationService)
            : base(1, roomDataService, soundPlayerService, navigationService)
        {
        }
    }
}
