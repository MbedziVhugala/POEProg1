using System;
using System.Media;
using System.Threading;

namespace POEProg1
{
    public class WelcomeScreen : BaseConsole
    {
        public void DisplayWelcome()
        {
            PlayWelcomeMessage(); // Play the welcome audio
            ShowAsciiArt();
            Console.WriteLine("\nWelcome to the Cybersecurity Awareness Chatbot!");
            Console.WriteLine("I'm here to help you learn about online safety and security.");
        }

        private void PlayWelcomeMessage()
        {
            try
            {
                // This assumes you have a WAV file named "welcome.wav" in your project
                // You'll need to record this file separately
                SoundPlayer player = new SoundPlayer("C:\\Users\\lab_services_student\\Desktop\\Cloud part1\\POEProg1\\welcome\\Welcome My name is A.wav");
                player.Play();

                // Wait a moment for the audio to play
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not play welcome message: {ex.Message}", ConsoleColor.Red);
                Thread.Sleep(2000); // Short delay to display the error message
            }
        }

        private void ShowAsciiArt()
        {
            Console.WriteLine(@"                              _     _               _   _               ", ConsoleColor.Cyan);
            Console.WriteLine(@"                             / \   (_) ___  __  / \ | | __ _ _ __    ", ConsoleColor.Cyan);
            Console.WriteLine(@"                            / _ \  | |/ _ \/ __|  / _ \| |/ _` | '_ \   ", ConsoleColor.Cyan);
            Console.WriteLine(@"                           / ___ \ | |  __/\__ \ / ___ \ | (_| | | | |  ", ConsoleColor.Cyan);
            Console.WriteLine(@"                          /_/   \_\|_|\___||___//_/   \_\_|\__,_|_| |_|  ", ConsoleColor.Cyan);
        }
    }
}
