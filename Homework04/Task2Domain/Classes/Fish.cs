using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Domain.Classes
{
    public class Fish:Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }
        public Fish(string name, string type, int age,string color, int size) : base(name, type, age)
        {
            Color = color;
            Size = size;
        }

        public override void PrintInfo()
        {
            if (Age < 0 || Size < 0)
            {
                throw new ArgumentException("Fish age and size can not be a negative number");
            }
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Color))
            {
                throw new ArgumentException("Fish name and color can not be a null or empty ");
            }
            Console.WriteLine("======Fish=========");
            Console.WriteLine($"The fish {Name} is {Age} years old and she is {Color}. Its size is {Size}cm");
        }
    }
}
