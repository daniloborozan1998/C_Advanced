using AnimalDogCatDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalDogCatDomain.Classes
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }


        public Animal(string name, string color, string race, int age)
        {
            Name = name;
            Color = color;
            Race = race;
            Age = age;
        }

        public void PrintAnimal()
        {
            Console.WriteLine($"Name: {Name} - Race: {Race} - Color: {Color} - Age: {Age}");
        }
    }
}
