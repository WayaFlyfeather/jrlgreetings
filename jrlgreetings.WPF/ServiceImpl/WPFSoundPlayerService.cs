using jrlgreetings.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace jrlgreetings.WPF.ServiceImpl
{
    public class WPFSoundPlayerService : ISoundPlayerService
    {
        MediaPlayer clickPlayer;
        MediaPlayer footstepsPlayer;
        MediaPlayer thunderPlayer;

        public WPFSoundPlayerService()
        {
            clickPlayer = new MediaPlayer();
            clickPlayer.Open(new Uri("Resources/click.mp3", UriKind.Relative));

            footstepsPlayer = new MediaPlayer();
            footstepsPlayer.Open(new Uri("Resources/footsteps.mp3", UriKind.Relative));

            thunderPlayer = new MediaPlayer();
            thunderPlayer.Open(new Uri("Resources/thunder.mp3", UriKind.Relative));
        }

        public void PlayClick()
        {
            clickPlayer.Stop();
            clickPlayer.Play();
        }

        public void PlayFootsteps()
        {
            footstepsPlayer.Stop();
            footstepsPlayer.Play();
        }

        public void PlayThunder()
        {
            thunderPlayer.Stop();
            thunderPlayer.Play();
        }
    }
}
