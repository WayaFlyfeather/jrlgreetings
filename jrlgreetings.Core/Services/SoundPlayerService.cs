using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace jrlgreetings.Core.Services
{
    public class SoundPlayerService : ISoundPlayerService
    {
        readonly ISimpleAudioPlayer thunderPlayer;
        readonly ISimpleAudioPlayer footstepsPlayer;
        readonly ISimpleAudioPlayer clickPlayer;

        public SoundPlayerService()
        {
            var assembly = typeof(SoundPlayerService).GetTypeInfo().Assembly;

            Stream thunderStream = assembly.GetManifestResourceStream("jrlgreetings.Core.thunder.mp3");
            thunderPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            thunderPlayer.Load(thunderStream);

            Stream footstepsStream = assembly.GetManifestResourceStream("jrlgreetings.Core.footsteps.mp3");
            footstepsPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            footstepsPlayer.Load(footstepsStream);

            Stream clickStream = assembly.GetManifestResourceStream("jrlgreetings.Core.click.mp3");
            clickPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            clickPlayer.Load(clickStream);
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
    }
}
