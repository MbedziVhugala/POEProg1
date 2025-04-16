using System;
using System.Media;
using System.Threading;
using System.IO;
namespace POEProg1
{ 



        internal class Program
        {

            // Colors for console formatting
            private static ConsoleColor titleColor = ConsoleColor.Cyan;
            private static ConsoleColor botColor = ConsoleColor.Green;
            private static ConsoleColor userColor = ConsoleColor.Yellow;
            private static ConsoleColor warningColor = ConsoleColor.Red;
            private static ConsoleColor infoColor = ConsoleColor.Blue;

            static void Main(string[] args)
            {
                // Initialize the chatbot
                InitializeChatbot();

                // Play welcome voice message
                PlayWelcomeMessage();

                // Display ASCII art and welcome message
                DisplayWelcomeScreen();

                // Get user's name and personalize interaction
                string userName = GetUserName();

                // Start main conversation loop
                RunChatbot(userName);
            }

            static void InitializeChatbot()
            {
                Console.Title = "Cybersecurity Awareness Chatbot";
                Console.Clear();
            }

            static void PlayWelcomeMessage()
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
                    Console.ForegroundColor = warningColor;
                    Console.WriteLine("Could not play welcome message: " + ex.Message);
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
            }

            static void DisplayWelcomeScreen()
            {
                Console.ForegroundColor = titleColor;
                Console.WriteLine(@"                              _     _               _   _               ");
                Console.WriteLine(@"                             / \   (_) ___  __  / \ | | __ _ _ __    ");
                Console.WriteLine(@"                            / _ \  | |/ _ \/ __|  / _ \| |/ _` | '_ \   ");
                Console.WriteLine(@"                           / ___ \ | |  __/\__ \ / ___ \ | (_| | | | |  ");
                Console.WriteLine(@"                          /_/   \_\|_|\___||___//_/   \_\_|\__,_|_| |_|  ");
                Console.ResetColor();

                Console.ForegroundColor = infoColor;
                Console.WriteLine("\nWelcome to the Cybersecurity Awareness Chatbot!");
                Console.WriteLine("I'm here to help you learn about online safety and security.");
                Console.ResetColor();
            }

            static string GetUserName()
            {
                Console.ForegroundColor = userColor;
                Console.Write("\nBefore we begin, what's your name? ");
                Console.ResetColor();

                string name = Console.ReadLine().Trim();

                while (string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor = warningColor;
                    Console.WriteLine("I didn't catch that. Could you please tell me your name?");
                    Console.ResetColor();
                    Console.ForegroundColor = userColor;
                    name = Console.ReadLine().Trim();
                    Console.ResetColor();
                }

                Console.ForegroundColor = botColor;
                Console.WriteLine($"\nNice to meet you, {name}! Let's talk about cybersecurity.");
                Console.ResetColor();

                return name;
            }

            static void RunChatbot(string userName)
            {
                bool continueChat = true;

                Console.ForegroundColor = infoColor;
                Console.WriteLine("\nYou can ask me about:");
                Console.WriteLine("- Password safety");
                Console.WriteLine("- Phishing scams");
                Console.WriteLine("- Safe browsing");
                Console.WriteLine("- General cybersecurity tips");
                Console.WriteLine("Or just say 'bye' to exit.");
                Console.ResetColor();

                while (continueChat)
                {
                    Console.ForegroundColor = userColor;
                    Console.Write($"\n{userName}: ");
                    string input = Console.ReadLine().Trim().ToLower();
                    Console.ResetColor();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.ForegroundColor = warningColor;
                        Console.WriteLine("Bot: I didn't hear anything. Could you repeat that?");
                        Console.ResetColor();
                        continue;
                    }

                    if (input.Contains("bye") || input.Contains("exit") || input.Contains("quit"))
                    {
                        continueChat = false;
                        Console.ForegroundColor = botColor;
                        Console.WriteLine($"Bot: Goodbye, {userName}! Stay safe online!");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        break;
                    }

                    string response = GenerateResponse(input, userName);
                    TypewriterEffect(response, botColor);
                }
            }

            static string GenerateResponse(string input, string userName)
            {
                if (input.Contains("how are you") || input.Contains("how's it going"))
                {
                    return "I'm just a bot, but I'm functioning well! Ready to help you with cybersecurity questions.";
                }
                else if (input.Contains("purpose") || input.Contains("what do you do"))
                {
                    return "My purpose is to help you learn about cybersecurity and stay safe online.";
                }
                else if (input.Contains("password") || input.Contains("safe password"))
                {
                    return "Strong passwords should be at least 12 characters long, include numbers, symbols, and both uppercase and lowercase letters. Never reuse passwords across different sites!";
                }
                else if (input.Contains("phishing") || input.Contains("scam"))
                {
                    return "Phishing scams try to trick you into giving personal information. Always check sender addresses, don't click suspicious links, and verify requests for sensitive info.";
                }
                else if (input.Contains("browsing") || input.Contains("internet safety"))
                {
                    return "For safe browsing: use HTTPS websites, keep your browser updated, avoid public Wi-Fi for sensitive tasks, and use a reputable antivirus.";
                }
                else if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
                {
                    return $"Hello again, {userName}! What cybersecurity topic would you like to discuss?";
                }
                else if (input.Contains("thank") || input.Contains("thanks"))
                {
                    return $"You're welcome, {userName}! I'm happy to help. Do you have any other cybersecurity questions?";
                }
                else
                {
                    return "I didn't quite understand that. I can help with password safety, phishing, safe browsing, and general cybersecurity tips. What would you like to know?";
                }
            }

            static void TypewriterEffect(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write("Bot: ");

                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(30); // Adjust speed as needed
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }




