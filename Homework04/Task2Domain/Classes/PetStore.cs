using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2Domain.Classes
{
    public static class PetStore<T> where T : Pet
    {
        public static List<T> Pet { get; set; }

        static PetStore()
        {
            Pet = new List<T>();
        }

        public static void PrintPets()
        {
            foreach (T pets in Pet)
            {
                Console.WriteLine($"Name: {pets.Name} Type: {pets.Type} Age: {pets.Age}");
            }
        }

        public static void BuyPet(T pets)
        {
            T existingItem = Pet.FirstOrDefault(x => x.Name == pets.Name);
            if (existingItem == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"There is no such pet name: {pets.Name}");
                Console.ResetColor();
                return;
            }
            Pet.Remove(pets);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Successfully completed");
            Console.ResetColor();
        }

    }
}
