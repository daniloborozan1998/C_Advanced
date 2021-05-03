using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Domain.Classes
{
    public class Cat: Pet
    {
        public string Lazy { get; set; }
        public int LivesLeft { get; set; }
        public Cat(string name, string type, int age, string lazy, int livesLeft) : base(name, type, age)
        {
            Lazy = lazy;
            LivesLeft = livesLeft;
        }

        public override void PrintInfo()
        {
            if (Age < 0 || LivesLeft < 0)
            {
                throw new ArgumentException("Cat age and LivesLeft can not be a negative number");
            }
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Lazy))
            {
                throw new ArgumentException("Cat name and lazy can not be a null or empty ");
            }
            Console.WriteLine("======Cat=========");
            Console.WriteLine($"The cat {Name} is {Age} years old and has {LivesLeft} lives left. Cat is {Lazy}");
        }
    }
}
