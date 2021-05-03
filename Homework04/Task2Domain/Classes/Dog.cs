using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Domain.Classes
{
    public class Dog : Pet
    {
        public string FavoriteFood { get; set; }
        public Dog(string name, string type, int age,string favoriteFood) : base(name, type, age)
        {
            FavoriteFood = favoriteFood;
        }

        public override void PrintInfo()
        {
            if (Age < 0)
            {
                throw new ArgumentException("Dog age can not be a negative number");
            }

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(FavoriteFood))
            {
                throw new ArgumentException("Dog name and food can not be a null or empty ");
            }
            Console.WriteLine("======Dog=========");
            Console.WriteLine($"The dog {Name} is {Age} years old. He likes to eat the most {FavoriteFood}");
        }
    }
}
