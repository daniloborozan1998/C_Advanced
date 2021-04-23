using System;
using System.Collections.Generic;
using System.Text;
using AnimalDogCatDomain.Enum;
using AnimalDogCatDomain.Interfaces;

namespace AnimalDogCatDomain.Classes
{
    public class Cat : Animal,ICat
    {
        public Genders Genders { get; set; }
        public bool Wild { get; set; }

        public Cat(string name, string color, string race, int age, Genders genders, bool wild) : base(name, color, race, age)
        {
            Genders = genders;
            Wild = wild;
        }

        public string Eat(string food)
        {
            return $"{Name} is a {Race} and must be eaten {food}";
        }
    }
}
