using jrlgreetings.Core.Services;
using jrlgreetings.FormsUI.ServiceImpl;
using MvvmCross;

namespace jrlgreetings.FormsUI
{
    public partial class Application
    {
        public Application()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            Mvx.IoCProvider.RegisterSingleton<ISoundPlayerService>(new SoundPlayerService());
            base.OnStart();
        }
    }
}
