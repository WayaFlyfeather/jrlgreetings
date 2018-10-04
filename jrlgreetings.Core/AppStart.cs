using jrlgreetings.Core.Services;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly IRoomDataService roomDataService;
        
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, IRoomDataService roomDataService)
            : base(application, navigationService)
        {
            this.roomDataService = roomDataService;
        }

        async protected override Task NavigateToFirstViewModel(object hint = null)
        {
            await roomDataService.InitAsync();
            await NavigationService.Navigate(roomDataService.GetViewModelForRoomNo(0));
        }
    }
}
