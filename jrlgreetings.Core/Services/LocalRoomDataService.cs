using jrlgreetings.Core.Models;
using jrlgreetings.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core.Services
{
    public class LocalRoomDataService : BaseRoomDataService
    {
        public override Task InitAsync()
        {
            Debug.WriteLine("In local init");
            makeLocalRooms();
            setViewModels();
            isReady = true;

            return Task.CompletedTask;
        }

        public LocalRoomDataService()
        {
        }

    }
}
