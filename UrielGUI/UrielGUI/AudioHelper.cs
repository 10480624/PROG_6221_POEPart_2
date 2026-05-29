using System;
using System.IO;
using System.Media;
using System.Runtime.Versioning;

namespace RaphaelGUI
{
    // This class is carried over from Part 1
    // Its only job is to handle the WAV voice greeting
    // It is kept separate so audio logic never mixes with UI or bot logic
    [SupportedOSPlatform("windows")]
    internal class AudioHelper
    {
        // Automatic property storing the path to the greeting WAV file
        // This satisfies the POE automatic property requirement
        public string GreetingPath { get; set; }

        // Constructor runs automatically when AudioHelper is created
        // It finds the greeting.wav file in the same folder as the exe
        // Using AppContext.BaseDirectory means it works on any machine
        public AudioHelper()
        {
            // PSEUDOCODE:
            // SET GreetingPath to the location of greeting.wav
            // in the same folder as the running application
        }

        // This method plays the voice greeting when the app starts
        // It is called once from MainForm constructor
        public void PlayGreeting()
        {
            // PSEUDOCODE:
            // IF greeting.wav file exists at GreetingPath THEN
            //     TRY to play it using SoundPlayer.PlaySync()
            //     PlaySync waits for audio to finish before continuing
            // IF file not found
            //     continue silently without crashing
            // IF playback fails for any reason
            //     continue silently without crashing
        }
    }
}
