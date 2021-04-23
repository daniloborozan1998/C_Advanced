using System;
using System.Collections.Generic;
using System.Text;
using AnimalDogCatDomain.Enum;
using AnimalDogCatDomain.Interfaces;

namespace AnimalDogCatDomain.Classes
{
    public class Dog : Animal, IDog
    {
        public Genders Genders { get; set; }

        public Dog(string name, string color, string race, int age, Genders genders) : base(name, color, race, age)
        {
            Genders = genders;
        }

        public void Bark()
        {
            Console.WriteLine($"{Name}: AW AW AW AW AW");
        }
    }
}
