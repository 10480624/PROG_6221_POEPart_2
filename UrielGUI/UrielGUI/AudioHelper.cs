using System.Media;

namespace UrielGUI
{
    public static class AudioHelper
    {
        public static void PlayStartup()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch { /* Silent fail if file missing */ }
        }
    }
}