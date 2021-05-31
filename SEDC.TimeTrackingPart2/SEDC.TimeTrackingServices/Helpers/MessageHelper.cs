using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingServices.Helpers
{
    public class MessageHelper
    {
        public static void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
