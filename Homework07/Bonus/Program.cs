using Bonus.Service;
using Bonus.Users;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bonus
{
    class Program
    {
        public static PersonService personService = new PersonService();
        public static List<Person> Persons = new List<Person>()
        {
            new Person("Danilo","Borozan","23"),
            new Person("Smith","Row","19"),
            new Person("Sergio","Ramos","34"),
            new Person("Anna","Annesky","20"),
            new Person("Lusy","Lusysky","26"),
        };
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=============First list============");
                foreach (var person in Persons)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(person.PrintPerson());
                    personService.Info($"{person.PrintPerson()}");
                    Console.ResetColor();
                }


                Console.WriteLine("============= The list from personInfo.txt ============");
                string line;
                List<Person> listOfPersons = new List<Person>();


                StreamReader file = new StreamReader(@"C:\Users\Danilo Borozan\Desktop\Homework07\Bonus\Exercise\personInfo.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    listOfPersons.Add(new Person(words[0], words[1], words[2]));
                }
                file.Close();

                foreach (Person listSecond in listOfPersons)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(listSecond.PrintPerson());
                    Console.ResetColor();
                }
            }
            catch(NullReferenceException e)
            {
                personService.Error("Null reference", e.Message);
            }
            catch(Exception e)
            {
                personService.Error("Exception", e.Message);
            }
            

            Console.ReadLine();
        }
    }
}
