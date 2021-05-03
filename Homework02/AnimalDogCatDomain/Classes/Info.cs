using AnimalDogCatDomain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalDogCatDomain.Classes
{
    public static class Info
    {
        public static List<Animal> Animals = new List<Animal>()
        {
            new Dog("Lessi", "Brown", "Labrador", 2, Genders.Female),
            new Dog("Bella", "Black and White", "Husky", 5, Genders.Female),
            new Dog("Rocky", "Yellow", "Chow chow", 2, Genders.Male),
            new Dog("Apollo", "White", "French bulldog", 3, Genders.Male),
            new Dog("Buddy", "Black", "Beagle", 1, Genders.Male),
            new Dog("Max", "Brown", "German Sheppard", 3, Genders.Male),
            new Dog("Lucy", "Brown and White", "Pekingese", 4, Genders.Female),
            new Dog("Luna", "White", "Corgi", 1, Genders.Female),
            new Cat("Lily", "White", "Abyssinian ", 1, Genders.Female, true),
            new Cat("Simba", "Yellow", "American Bobtail ", 1, Genders.Male, false),
            new Cat("Gracie", "Black", "American Curl", 1, Genders.Female, false),
            new Cat("Molly", "Black and White", "American Shorthair", 1, Genders.Female, true),
            new Cat("Chloe", "White", "Bengal ", 1, Genders.Female, false),
            new Cat("Charlie", "Black", "Birman", 1, Genders.Male, true),
            new Cat("Bella", "White", "Birman", 1, Genders.Female, false),
            new Cat("Tiger", "Brown", "Birman", 1, Genders.Male, true)
        };
    }
}
