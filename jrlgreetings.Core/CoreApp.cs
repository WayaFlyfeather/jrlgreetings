using jrlgreetings.Core.Services;
using MvvmCross;
using MvvmCross.IoC;

namespace jrlgreetings.Core
{
    public class CoreApp : MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IRoomDataService, WebRoomDataService>();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
