using System;
using System.Collections.Generic;
using Task2Domain.Classes;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            PetStore<Pet>.Pet.Add(new Dog("Lucy", "Afador", 2,"Meal"));
            PetStore<Pet>.Pet.Add(new Dog("Daisy", "Barbet", 3, "Peanut Butter"));
            PetStore<Pet>.Pet.Add(new Dog("Hamilton", "Hamiltonstovare", 1, "Cheese"));
            PetStore<Pet>.Pet.Add(new Dog("Bella", "English Cocker", 2, "Salmon"));
            PetStore<Pet>.Pet.Add(new Cat("Lily", "Persian", 2,"not Lazy",7));
            PetStore<Pet>.Pet.Add(new Cat("Milo", "Japanese Bobtail", 3,"Lazy",5));
            PetStore<Pet>.Pet.Add(new Cat("Jack", "Snowshoe", 5,"Lazy",5));
            PetStore<Pet>.Pet.Add(new Cat("Kitty", "Calico", 1,"not Lazy",11));
            PetStore<Pet>.Pet.Add(new Fish("Flounder","Goldfish",1,"Orange",50));
            PetStore<Pet>.Pet.Add(new Fish("Marlin", "Blue tang",1,"Blue",30));
            PetStore<Pet>.Pet.Add(new Fish("Blackfin ", "Tuna", 2, "Black ", 130));
            PetStore<Pet>.Pet.Add(new Fish("Hogfish", "Northern pike",1,"Gray",103));
            PetStore<Pet>.Pet.Add(new Fish("Pompano", "Wels catfish",1,"Green",80));


            Console.WriteLine("======= Welcome to PETS STORE =========");
            Console.WriteLine("======= All info for Pets =========");
            foreach (Pet pets in PetStore<Pet>.Pet)
            {
                pets.PrintInfo();
            }
            Console.WriteLine("========================");

            PetStore<Pet>.BuyPet(PetStore<Pet>.Pet[2]);
            PetStore<Pet>.BuyPet(PetStore<Pet>.Pet[5]);
            PetStore<Pet>.BuyPet(PetStore<Pet>.Pet[9]);
            Console.WriteLine("======= All Pets after buying =========");
            PetStore<Pet>.PrintPets();
            Console.WriteLine("========================");



            Console.ReadLine();
        }
    }
}
