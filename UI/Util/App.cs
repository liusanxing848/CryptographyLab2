using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.UI.Util
{
    internal class App
    {
        public static void ConsoleWriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void ConsoleWriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void ConsoleWriteYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        
    }
}
