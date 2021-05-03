using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Domain.Classes
{
    public static class GenericHelperDb
    {
        public static void PrintType(this Shape shapes)
        {
            Console.WriteLine($" ID: {shapes.ID} Type: {shapes.GetType()} ");
        }
    }
}
