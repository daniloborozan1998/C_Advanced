using System;
using System.Collections.Generic;
using Task1Domain;

namespace Task1App
{
    class Program
    {
        public static DataBase DogsDb = new DataBase();
        public static void PrintInfoAllDogs()
        {
            List<Dog> dogs = DogsDb.GetAllDogs();
            foreach (Dog dog in dogs)
            {
                Console.WriteLine(dog.GetInfo());
            }
        }
        public static void DogData()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter a name..Try again");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Enter age");
                    bool success = int.TryParse(Console.ReadLine(), out int age);
                    if (success && age > 0)
                    {
                        Console.WriteLine("Enter color");
                        string color = Console.ReadLine();
                        if (string.IsNullOrEmpty(color))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You must enter a color..Try again");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Dog newDog = new Dog();
                            newDog.Name = name;
                            newDog.Age = age;
                            newDog.Color = color;
                            DogsDb.Insert(newDog);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Successfully added the dog!!!");
                            Console.ResetColor();
                            Console.ReadKey();
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You must enter a number greater than 0..Try again");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        flag = true;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Dog firstDog = DogsDb.GetById(1);
            if (firstDog != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All Dogs");
                Console.ResetColor();
                PrintInfoAllDogs();
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Do you want to add other dog? (yes or no)");
                    string answer = Console.ReadLine();
                    if (answer == "yes")
                    {
                        Console.Clear();
                        DogData();
                        flag = false;
                    }
                    else if (answer == "no")
                    {
                        Console.WriteLine("GoodBye");
                        flag = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You must enter yes or no");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                DogData();
            }
            Console.ReadLine();
        }
    }
}
