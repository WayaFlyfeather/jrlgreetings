using jrlgreetings.Core.Services;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace jrlgreetings.FormsUI.ServiceImpl
{
    public class SoundPlayerService : ISoundPlayerService
    {
        readonly ISimpleAudioPlayer thunderPlayer;
        readonly ISimpleAudioPlayer footstepsPlayer;
        readonly ISimpleAudioPlayer clickPlayer;
        readonly ISimpleAudioPlayer fireworksPlayer;

        public SoundPlayerService()
        {
            var assembly = typeof(SoundPlayerService).GetTypeInfo().Assembly;

            Stream thunderStream = assembly.GetManifestResourceStream("jrlgreetings.FormsUI.thunder.mp3");
            thunderPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            thunderPlayer.Load(thunderStream);

            Stream footstepsStream = assembly.GetManifestResourceStream("jrlgreetings.FormsUI.footsteps.mp3");
            footstepsPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            footstepsPlayer.Load(footstepsStream);

            Stream clickStream = assembly.GetManifestResourceStream("jrlgreetings.FormsUI.click.mp3");
            clickPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            clickPlayer.Load(clickStream);

            Stream fireworksStream = assembly.GetManifestResourceStream("jrlgreetings.FormsUI.fireworks.mp3");
            fireworksPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            fireworksPlayer.Load(fireworksStream);
        }

        public void PlayFootsteps()
        {
            footstepsPlayer.Play();
        }

        public void PlayThunder()
        {
            thunderPlayer.Play();
        }

        public void PlayClick()
        {
            clickPlayer.Play();
        }

        public void PlayFireworks()
        {
            fireworksPlayer.Play();
        }
    }
}
