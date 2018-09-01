using jrlgreetings.Core.Models;
using jrlgreetings.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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

            return Task.CompletedTask;
        }

        public LocalRoomDataService()
        {
        }

    }
}
