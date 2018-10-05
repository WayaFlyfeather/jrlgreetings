using jrlgreetings.Core.Services;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class NorthWestViewModel : BaseViewModel
    {
        public NorthWestViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(0, roomDataService, navigationService)
        {
            annoyanceFactor = 90.0;
        }
    }
}
