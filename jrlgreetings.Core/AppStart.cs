using jrlgreetings.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core
{
    public class AppStart : IMvxAppStart
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IRoomDataService roomDataService;
        
        public AppStart(IRoomDataService roomDataService, IMvxNavigationService navigationService)
        {
            this.roomDataService = roomDataService;
            this.navigationService = navigationService;
        }

        
        public void Start(object hint = null)
        {
            try
            {
                roomDataService.InitAsync().GetAwaiter().GetResult();
                navigationService.Navigate(roomDataService.GetViewModelForRoomNo(0)).GetAwaiter().GetResult();
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Exception in AppStart.Start: {0}", e.Message);
            }
        }
    }
}
