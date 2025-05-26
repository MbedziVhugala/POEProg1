using System;
using System.Collections.Generic;

namespace POEProg1
{
    public class Chatbot : BaseConsole
    {
        private List<string> memoryLog;
        private Dictionary<string, List<string>> keywordResponses;

        public Chatbot()
        {
            memoryLog = new List<string>();

            // Initialize dictionary of keyword to response list
            keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "phishing", new List<string> {
                    "Phishing scams try to trick you into giving personal information. Always check sender addresses and avoid clicking suspicious links. Do you need more tips?",
                    "Phishing emails often create urgency to trick you. Would you like advice on recognizing phishing emails?"
                }},
                { "password", new List<string> {
                    "Strong passwords should be at least 12 characters long, include numbers, symbols, and both uppercase and lowercase letters. Would you like advice on managing passwords securely?",
                    "Using a password manager helps keep your passwords safe. Want to know more?"
                }},
                { "browsing", new List<string> {
                    "For safe browsing: use HTTPS websites, keep your browser updated, and avoid public Wi-Fi for sensitive tasks. Do you need help with configuring your browser settings?",
                    "Clearing your cache and cookies regularly can improve your browsing security."
                }},
                { "banking", new List<string> {
                    "Online banking security is critical. Use two-factor authentication and avoid saving passwords in your browser. Would you like to know how to set up 2FA?",
                    "Be sure to log out after online banking sessions, especially on shared devices."
                }}
            };
        }

        public string GetUserName()
        {
            Console.WriteLine("\nBefore we begin, what's your name?", ConsoleColor.Yellow);

            string name = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("I didn't catch that. Could you please tell me your name?");
                name = Console.ReadLine().Trim();
            }

            Console.WriteLine($"\nNice to meet you, {name}! Let's talk about cybersecurity.");

            return name;
        }

        public void RunChat(string userName)
        {
            bool continueChat = true;

            Console.WriteLine("\nYou can ask me about:");
            Console.WriteLine("- Password safety\n- Phishing scams\n- Safe browsing\n- Banking security\n- General cybersecurity tips\nOr just say 'bye' to exit.");

            while (continueChat)
            {
                Console.WriteLine($"\n{userName}: ");
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Bot: I didn't hear anything. Could you repeat that?");
                    continue;
                }

                if (input.Contains("bye") || input.Contains("exit") || input.Contains("quit"))
                {
                    continueChat = false;
                    Console.WriteLine($"Bot: Goodbye, {userName}! Stay safe online!");
                    break;
                }

                string response = GenerateResponse(input);
                TypewriterEffect($"Bot: {response}", ConsoleColor.Green);

                memoryLog.Add(input); // Save user input to memory
            }
        }

        private string lastTopic; // Stores last discussed topic for follow-ups

        private string GenerateResponse(string input)
        {
            bool isWorried = input.Contains("worried") || input.Contains("scared") || input.Contains("anxious");
            bool isCurious = input.Contains("curious") || input.Contains("wondering") || input.Contains("interested");
            bool isFrustrated = input.Contains("frustrated") || input.Contains("angry") || input.Contains("upset");

            // Follow-Up and Affirmative Handling
            if (input.Contains("yes") || input.Contains("sure") || input.Contains("please"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    return ProvideAdditionalTips(lastTopic);
                }
                return "Could you remind me what we were discussing? I'd love to give you more tips.";
            }

            if (input.Contains("what about that") || input.Contains("can you tell me more") || input.Contains("how does that work"))
            {
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    return GenerateFollowUpResponse(lastTopic);
                }
                return "Could you remind me what we were discussing? I'd be happy to elaborate.";
            }

            // Keyword Detection using dictionary
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastTopic = keyword;

                    // Pick a random response from the list for variety
                    var responses = keywordResponses[keyword];
                    var random = new Random();
                    var chosenResponse = responses[random.Next(responses.Count)];

                    // If user seems worried, prepend empathetic message
                    if (isWorried)
                    {
                        return $"I understand why {keyword} concerns you. {chosenResponse}";
                    }

                    return chosenResponse;
                }
            }

            // Sentiment Handling (if no keyword matched)
            if (isWorried)
            {
                return "It sounds like something's worrying you. I'm here to help. Could you tell me more about what's on your mind?";
            }
            else if (isCurious)
            {
                return "I'm glad you're curious! What would you like to learn more about?";
            }
            else if (isFrustrated)
            {
                return "I'm sorry you're feeling frustrated. Maybe I can help resolve your concerns. What's bothering you?";
            }

            // Default Unknown Response
            return "I'm sorry, I didn't quite understand that. Could you please rephrase or provide more details?";
        }

        private string ProvideAdditionalTips(string topic)
        {
            switch (topic)
            {
                case "phishing":
                    return "Here are more tips on phishing:\n- Verify links by hovering over them to see the URL.\n- Avoid downloading email attachments from unknown sources.\n- Report phishing emails to your email provider.";
                case "password":
                    return "Here are more tips for secure passwords:\n- Use a password manager to generate and store unique passwords.\n- Avoid using personal information in passwords.\n- Enable two-factor authentication wherever possible.";
                case "browsing":
                    return "For safer browsing:\n- Use privacy-focused browser extensions like ad blockers.\n- Clear your cookies and cache regularly.\n- Avoid clicking on pop-up ads.";
                case "banking":
                    return "For online banking security:\n- Log out after each session, especially on shared devices.\n- Avoid using public Wi-Fi for transactions.\n- Regularly monitor your accounts for unauthorized transactions.";
                default:
                    return "I'm sorry, I don't have additional tips on that topic at the moment. Let me know if there's another topic you'd like to discuss.";
            }
        }

        private string GenerateFollowUpResponse(string topic)
        {
            switch (topic)
            {
                case "phishing":
                    return "Phishing emails often create a sense of urgency to trick you into acting quickly. Have you encountered any suspicious emails recently?";
                case "password":
                    return "Password managers can make it easier to manage strong passwords. Would you like advice on choosing a password manager?";
                case "browsing":
                    return "Using a VPN can improve your online privacy and security. Would you like to learn how to set one up?";
                case "banking":
                    return "Two-factor authentication (2FA) adds an extra layer of security to your accounts. Would you like me to explain how to enable it?";
                default:
                    return "Could you remind me what we were discussing? I'd be happy to help.";
            }
        }

        // You can keep your existing TypewriterEffect method here
        private void TypewriterEffect(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(25);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
