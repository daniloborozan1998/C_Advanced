using System;
using System.Collections.Generic;
using AnimalDogCatDomain.Classes;
using AnimalDogCatDomain.Enum;

namespace AnimalsDogCat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> Dogs = new List<Animal>()
            {
                new Dog("Lessi", "Brown", "Labrador", 2, Genders.Female),
                new Dog("Bella", "Black and White", "Husky", 5, Genders.Female),
                new Dog("Rocky", "Yellow", "Chow chow", 2, Genders.Male),
                new Dog("Apollo", "White", "French bulldog", 3, Genders.Male),
                new Dog("Buddy", "Black", "Beagle", 1, Genders.Male),
                new Dog("Max", "Brown", "German Sheppard", 3, Genders.Male),
                new Dog("Lucy", "Brown and White", "Pekingese", 4, Genders.Female),
                new Dog("Luna", "White", "Corgi", 1, Genders.Female)
            };
            Dog dog1 = new Dog("Lessi", "Brown", "Labrador", 2, Genders.Female);
            Dog dog2 = new Dog("Bella", "Black and White", "Husky", 5, Genders.Female);
            Dog dog3 = new Dog("Rocky", "Yellow", "Chow chow", 2, Genders.Male);
            Dog dog4 = new Dog("Apollo", "White", "French bulldog", 3, Genders.Male);
            Dog dog5 = new Dog("Buddy", "Black", "Beagle", 1, Genders.Male);
            Dog dog6 = new Dog("Max", "Brown", "German Sheppard", 3, Genders.Male);
            Dog dog7 = new Dog("Lucy", "Brown and White", "Pekingese", 4, Genders.Female);
            Dog dog8 = new Dog("Luna", "White", "Corgi", 1, Genders.Female);

            Cat cat1 = new Cat("Lily", "White", "Abyssinian ", 1, Genders.Female, true);
            Cat cat2 = new Cat("Simba", "Yellow", "American Bobtail ", 1, Genders.Male, false);
            Cat cat3 = new Cat("Gracie", "Black", "American Curl", 1, Genders.Female, false);
            Cat cat4 = new Cat("Molly", "Black and White", "American Shorthair", 1, Genders.Female, true);
            Cat cat5 = new Cat("Chloe", "White", "Bengal ", 1, Genders.Female, false);
            Cat cat6 = new Cat("Charlie", "Black", "Birman", 1, Genders.Male, true);
            Cat cat7 = new Cat("Bella", "White", "Birman", 1, Genders.Female, false);
            Cat cat8 = new Cat("Tiger", "Brown", "Birman", 1, Genders.Male, true);

            bool flag = true;
            while (flag)
            {
                try
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("============= Welcome ================");
                        Console.WriteLine("Pleas enter 1 or 2");
                        Console.WriteLine("1) Dog");
                        Console.WriteLine("2) Cat");
                        Console.WriteLine("3) Bonus");
                        Console.WriteLine("4) Exit");
                        Console.WriteLine("=============================");
                        bool succ = int.TryParse(Console.ReadLine(), out int answer);
                        if (succ)
                        {
                            if (answer == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;


                                Console.WriteLine("========INFO======");
                                Console.WriteLine("===First dog===");
                                Console.WriteLine(dog1.GetType());
                                dog1.PrintAnimal();
                                dog1.Bark();
                                Console.WriteLine("===Second dog===");
                                Console.WriteLine(dog2.GetType());
                                dog2.PrintAnimal();
                                dog2.Bark();
                                Console.WriteLine("===Third dog===");
                                Console.WriteLine(dog3.GetType());
                                dog3.PrintAnimal();
                                dog3.Bark();
                                Console.WriteLine("===Fourth dog===");
                                Console.WriteLine(dog4.GetType());
                                dog4.PrintAnimal();
                                dog4.Bark();
                                Console.WriteLine("===Fifth dog===");
                                Console.WriteLine(dog5.GetType());
                                dog5.PrintAnimal();
                                dog5.Bark();
                                Console.WriteLine("===Sixth dog===");
                                Console.WriteLine(dog6.GetType());
                                dog6.PrintAnimal();
                                dog6.Bark();
                                Console.WriteLine("===Seventh dog===");
                                Console.WriteLine(dog7.GetType());
                                dog7.PrintAnimal();
                                dog7.Bark();
                                Console.WriteLine("===Eighth dog===");
                                Console.WriteLine(dog8.GetType());
                                dog8.PrintAnimal();
                                dog8.Bark();
                                Console.ResetColor();

                            }
                            else if (answer == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("========INFO======");
                                Console.WriteLine("===First cat===");
                                Console.WriteLine(cat1.GetType());
                                cat1.PrintAnimal();
                                cat1.Eat("Milk");
                                Console.WriteLine($"{cat1.Name} is wild: { cat1.Wild}");
                                Console.WriteLine("===Second cat===");
                                Console.WriteLine(cat2.GetType());
                                cat2.PrintAnimal();
                                cat2.Eat("Fish");
                                Console.WriteLine($"{cat2.Name} is wild:{cat2.Wild}");
                                Console.WriteLine("===Third cat===");
                                Console.WriteLine(cat3.GetType());
                                cat3.PrintAnimal();
                                cat3.Eat("Milk");
                                Console.WriteLine($"{cat3.Name} is wild:{cat3.Wild}");
                                Console.WriteLine("===Fourth cat===");
                                Console.WriteLine(cat4.GetType());
                                cat4.PrintAnimal();
                                cat4.Eat("Fish");
                                Console.WriteLine($"{cat4.Name} is wild: {cat4.Wild}");

                                Console.WriteLine("===Fifth cat===");
                                Console.WriteLine(cat5.GetType());
                                cat5.PrintAnimal();
                                cat5.Eat("Cheese");
                                Console.WriteLine($"{cat5.Name} is wild:{cat5.Wild}");
                                Console.WriteLine("===Sixth cat===");
                                Console.WriteLine(cat6.GetType());
                                cat6.PrintAnimal();
                                cat6.Eat("Carrots");
                                Console.WriteLine($"{cat6.Name} is wild: { cat6.Wild}");
                                Console.WriteLine("===Seventh cat===");
                                Console.WriteLine(cat7.GetType());
                                cat7.PrintAnimal();
                                cat7.Eat("Meat");
                                Console.WriteLine($"{cat7.Name} is wild: { cat7.Wild}");
                                Console.WriteLine("===Eighth cat===");
                                Console.WriteLine(cat8.GetType());
                                cat8.PrintAnimal();
                                cat8.Eat("Rice");
                                Console.WriteLine($"{cat8.Name} is wild:{cat8.Wild}");
                                Console.ResetColor();
                            }
                            else if (answer == 3)
                            {
                                if (Info.Animals != null)
                                {
                                    foreach (var animal in Info.Animals)
                                    {
                                        if (animal.GetType() == dog1.GetType())
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("=====Dog=======");
                                            ((Dog)animal).Bark();
                                            Console.ResetColor();
                                        }
                                        else if (animal.GetType() == cat1.GetType())
                                        {

                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("=====Cat=======");
                                            Console.WriteLine(((Cat)animal).Eat("Milk and Fish"));
                                            Console.ResetColor();
                                        }
                                    }
                                }
                            }else if (answer == 4)
                            {
                                Environment.Exit(-1);
                            }
                            else
                            {
                                throw new Exception("Must be enter 1, 2, or 3");
                            }
                            
                        }
                        else
                        {
                            throw new Exception("Invalid input!!!");
                        }
                        Console.WriteLine("=======================");
                        Console.WriteLine("Press enter to back to main menu");
                        Console.ReadLine();
                    }
                    

                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Animal does not exist");
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.Message);

                }
                Console.WriteLine("Do you want try again? y/n");
                string again = Console.ReadLine();
                if (again.ToLower() == "y")
                {
                    flag = true;
                    Console.Clear();
                }
                else
                {
                    flag = false;
                    Console.WriteLine("=====Goodbye=====");
                }
            }

            

            Console.ReadLine();
        }
    }
}
