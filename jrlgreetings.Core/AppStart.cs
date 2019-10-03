using jrlgreetings.Core.Services;
using jrlgreetings.Core.ViewModels;
using MvvmCross;
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

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            //seems this should be async and awaitable - but doesn't work
            roomDataService.InitAsync().GetAwaiter().GetResult();
            //            NavigationService.Navigate(roomDataService.GetViewModelForRoomNo(0)).GetAwaiter().GetResult();
            NavigationService.Navigate(new EntranceViewModel("hello", roomDataService, Mvx.IoCProvider.Resolve<IMvxNavigationService>()));

            return Task.CompletedTask;
        }
    }
}
