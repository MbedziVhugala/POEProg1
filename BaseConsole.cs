using System;
using System.Threading;

namespace POEProg1
{
    public class BaseConsole
    {
        protected static ConsoleColor TitleColor = ConsoleColor.Cyan;
        protected static ConsoleColor BotColor = ConsoleColor.Green;
        protected static ConsoleColor UserColor = ConsoleColor.Yellow;
        protected static ConsoleColor WarningColor = ConsoleColor.Red;
        protected static ConsoleColor InfoColor = ConsoleColor.Blue;

        protected void TypewriterEffect(string text, ConsoleColor color)
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
