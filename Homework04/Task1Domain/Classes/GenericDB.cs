using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Domain.Classes
{
    public static class GenericDB<T> where T : Shape
    {
        public static List<T> Shape { get; set; }

        static GenericDB()
        {
            Shape = new List<T>();
        }

        public static void PrintArea()
        {
            foreach (T areaShape in Shape)
            {
                Console.WriteLine($"Area is: {areaShape.GetArea()}");
                
            }
        }

        public static void PrintPerimeter()
        {
            foreach (T perimeterShape in Shape)
            {
                Console.WriteLine($"Perimeter is: {perimeterShape.GetPerimeter()}");
            }
        }

    }
}
