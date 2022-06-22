using System;
using System.Collections.Generic;
using System.Text;

namespace PR1
{
    class ConsoleColors
    {
        public void InitiateColors(string title)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
