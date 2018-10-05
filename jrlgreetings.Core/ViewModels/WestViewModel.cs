using jrlgreetings.Core.Services;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class WestViewModel : BaseViewModel
    {
        public WestViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(3, roomDataService, navigationService)
        {
        }
    }
}
