using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using jrlgreetings.Core.Services;

namespace jrlgreetings.Native.Droid.ServiceImpl
{
    public class AndroidSoundPlayerService : ISoundPlayerService
    {
        readonly int thunderResource = Resource.Raw.thunder;
        readonly int footstepsResource = Resource.Raw.footsteps;
        readonly int clickResource = Resource.Raw.click;

        readonly int thunderSound;
        readonly int footstepsSound;
        readonly int clickSound;

        SoundPool soundPool;

        public AndroidSoundPlayerService()
        {
            soundPool = new SoundPool.Builder()
                .SetMaxStreams(2)
                .SetAudioAttributes(
                    new AudioAttributes.Builder()
                    .SetUsage(AudioUsageKind.Game)
                    .SetContentType(AudioContentType.Sonification)
                    .Build())
                .Build();
            footstepsSound = soundPool.Load(Application.Context, footstepsResource, 1);
            thunderSound = soundPool.Load(Application.Context, thunderResource, 1);
            clickSound = soundPool.Load(Application.Context, clickResource, 1);

        }

        public void PlayFootsteps()
        {
            soundPool.Play(footstepsSound, 1.0f, 1.0f, 1, 0, 1.0f);
        }

        public void PlayThunder()
        {
            soundPool.Play(thunderSound, 0.5f, 0.5f, 1, 0, 1.0f);
        }

        public void PlayClick()
        {
            soundPool.Play(clickSound, 0.5f, 0.5f, 1, 0, 1.0f);
        }
    }
}