using System;
using System.Threading;

namespace Core.Helpers
{
    public class MyConsole
    {
        public static void WriteLine(object text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Write(object text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            Console.WriteLine("");
        }

        public static void WriteFormat(string text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            foreach (var item in text)
            {
                Thread.Sleep(100);
                Console.Write(item);

            }
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}
