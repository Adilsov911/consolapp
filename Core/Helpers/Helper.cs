using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class Helper
    {
        public static void WriteTextWithColor(ConsoleColor color,string text)
        {
            Console.ForegroundColor = color
            ;Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
