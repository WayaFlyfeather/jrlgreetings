using jrlgreetings.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core.Services
{
    public interface IRoomDataService
    {
        Task InitAsync();

        bool IsReady { get; }

        Room GetRoomForRoomNo(int roomNo);
        int Completed { get; }
        int UnCompleted { get; }
        IEnumerable<bool> RoomCompletionInfo { get; }

        Task MarkRoomCompleted(int roomNo);

        int CurrentLocation { get; }
        IMvxViewModel CurrentLocationViewModel { get; }
        bool CanGoNorth { get; }
        bool CanGoEast { get; }
        bool CanGoWest { get; }
        bool CanGoSouth { get; }

        Task GoNorthAsync();
        Task GoEastAsync();
        Task GoWestAsync();
        Task GoSouthAsync();
        Task GoToRoomNoAsync(int roomNo);

        IMvxViewModel GetViewModelForRoomNo(int roomNo);

        event EventHandler CurrentLocationChanged;
        event EventHandler TempleIsCompleted;
    }
}
