using jrlgreetings.Core.Services;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace jrlgreetings.Core.ViewModels
{
    public class NorthViewModel : BaseViewModel
    {
        public NorthViewModel(IRoomDataService roomDataService, IMvxNavigationService navigationService)
            : base(1, roomDataService, navigationService)
        {
        }
    }
}
