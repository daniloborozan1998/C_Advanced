using System;
using System.Collections.Generic;
using Task1Domain.Classes;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericDB<Shape>.Shape.Add(new Circle(1,3));
            GenericDB<Shape>.Shape.Add(new Circle(2,4));
            GenericDB<Shape>.Shape.Add(new Circle(3,5));
            GenericDB<Shape>.Shape.Add(new Circle(4,6.2));
            GenericDB<Shape>.Shape.Add(new Rectangle(5,4,5));
            GenericDB<Shape>.Shape.Add(new Rectangle(6,5.5,6));
            GenericDB<Shape>.Shape.Add(new Rectangle(7,4.2,5.6));
            GenericDB<Shape>.Shape.Add(new Rectangle(8,6,15));
            //GenericDB<Shape>.Shape.Add(new Rectangle(9,0,15));

            Console.WriteLine("====Type===");
            Console.WriteLine("===================================");
            foreach (Shape shape in GenericDB<Shape>.Shape)
            {
                shape.PrintType();
            }
            Console.WriteLine("===================================");

            Console.WriteLine("==== Area ===");
            GenericDB<Shape>.PrintArea();
            Console.WriteLine("===================================");
            Console.WriteLine("==== Perimeter ===");
            GenericDB<Shape>.PrintPerimeter();
            Console.WriteLine("===================================");

            








            Console.ReadLine();
        }
    }
}
