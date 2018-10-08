using jrlgreetings.Core.Services;
using jrlgreetings.WPF.ServiceImpl;
using MvvmCross;
using MvvmCross.Platforms.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.WPF
{
    public class Setup : MvxWpfSetup<Core.CoreApp>
    {
        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
            Mvx.IoCProvider.RegisterSingleton<ISoundPlayerService>(new WPFSoundPlayerService());
        }
    }
}
