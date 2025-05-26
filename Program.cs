using System;

namespace POEProg1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create instances of derived classes
                WelcomeScreen welcomeScreen = new WelcomeScreen();
                Chatbot chatbot = new Chatbot();

                // Display the welcome screen
                welcomeScreen.DisplayWelcome();

                // Get the user's name
                string userName = chatbot.GetUserName();

                // Option to replay the welcome screen
                Console.WriteLine("\nWould you like to replay the welcome message? (yes/no)");
                string replayChoice = Console.ReadLine()?.Trim().ToLower();
                if (replayChoice == "yes")
                {
                    welcomeScreen.DisplayWelcome();
                }

                // Start the chatbot interaction
                chatbot.RunChat(userName);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nThank you for using the Cybersecurity Awareness Chatbot. Stay safe online!");
            }
        }
    }
}
