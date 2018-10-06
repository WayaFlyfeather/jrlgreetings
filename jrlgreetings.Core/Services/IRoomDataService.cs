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

        Room GetRoomForRoomNo(int roomNo);
        int Completed { get; }
        int UnCompleted { get; }
        IEnumerable<bool> RoomCompletionInfo { get; }

        IMvxViewModel GetViewModelForRoomNo(int roomNo);
    }
}
