using jrlgreetings.Core.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace jrlgreetings.Core
{
    public class CoreApp : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton<IRoomDataService, WebRoomDataService>();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
