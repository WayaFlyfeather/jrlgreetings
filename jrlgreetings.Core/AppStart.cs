using jrlgreetings.Core.Services;
using jrlgreetings.Core.ViewModels;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

        protected async override Task NavigateToFirstViewModel(object hint = null)
        {            
            var init = roomDataService.InitAsync().ConfigureAwait(false);
            
            await NavigationService.Navigate(new EntranceViewModel(roomDataService, Mvx.IoCProvider.Resolve<IMvxNavigationService>()));
        }
    }
}
