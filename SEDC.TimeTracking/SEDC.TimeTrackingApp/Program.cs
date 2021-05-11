using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Models;
using SEDC.TimeTrackingServices.Implementations;
using SEDC.TimeTrackingServices.Interfaces;

namespace SEDC.TimeTrackingApp
{
    class Program
    {
        public static IUserService<Users> _users = new UserService<Users>();
        public static ITrackService<Exercising> _exercising = new TrackService<Exercising>();
        public static ITrackService<Readings> _readings = new TrackService<Readings>();
        public static ITrackService<Working> _working = new TrackService<Working>();
        static void Main(string[] args)
        {
            _users.AddUser(new Users()
            {
                Id = 1,
                FirstName = "Danilo",
                LastName = "Borozan",
                Age = 23,
                Username = "danilo123",
                Password = "Dajo123"

            });
            _users.AddUser(new Users()
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Anski",
                Age = 24,
                Username = "anna98",
                Password = "12345A"

            });
            _users.AddUser(new Users()
            {
                Id = 3,
                FirstName = "Smith",
                LastName = "Row",
                Age = 19,
                Username = "smith12",
                Password = "roWsmith12"

            });
            _users.AddUser(new Users()
            {
                Id = 4,
                FirstName = "Sergio",
                LastName = "Ramos",
                Age = 34,
                Username = "real04",
                Password = "Madrid04"

            });
            _users.AddUser(new Users()
            {
                Id = 5,
                FirstName = "Lusy",
                LastName = "Lusitania",
                Age = 27,
                Username = "lusy27",
                Password = "Lusti27"
            });


            _exercising.AddTrack(new Exercising()
            {
                Tittle = "General",
                Description = "General EXERCISING",
                Time = 22.3,
                Exercisings = new List<ExercisingTypes>()
                {
                    ExercisingTypes.General,
                    ExercisingTypes.Running,
                    ExercisingTypes.Sport
                }
            });
            _exercising.AddTrack(new Exercising()
            {
                Tittle = "Sport",
                Description = "Sport EXERCISING",
                Time = 12.3,
                Exercisings = new List<ExercisingTypes>()
                {
                    ExercisingTypes.Sport
                }
            });
            _exercising.AddTrack(new Exercising()
            {
                Tittle = "Running",
                Description = "Running EXERCISING",
                Time = 52.3,
                Exercisings = new List<ExercisingTypes>()
                {
                    ExercisingTypes.General,
                    ExercisingTypes.Running,
                   
                }
            });
            _readings.AddTrack(new Readings()
            {
                Page = 100,
                Tittle = "Bell",
                Description = "Bell Reading",
                Time = 120,
                Readings = new List<ReadingTypes>()
                {
                    ReadingTypes.BellesLettres,
                    ReadingTypes.Fiction,
                    ReadingTypes.ProfessionalLiterature
                }
            });
            _readings.AddTrack(new Readings()
            {
                Page = 50,
                Tittle = "Fiction",
                Description = "Fiction Reading",
                Time = 60,
                Readings = new List<ReadingTypes>()
                {
                    ReadingTypes.Fiction
                }
            });
            _readings.AddTrack(new Readings()
            {
                Page = 10,
                Tittle = "Literature",
                Description = "Professional Literature Reading",
                Time = 120,
                Readings = new List<ReadingTypes>()
                {
                    ReadingTypes.ProfessionalLiterature
                }
            });

            _users.ShowMainMenu();

            while (true)
            {
                bool succ = int.TryParse(Console.ReadLine(), out int num);
                if (succ)
                {
                    if (num < 1 || num >2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Wrong input. Try Again!");
                        Console.ResetColor();
                        Console.Clear();
                        _users.ShowMainMenu();
                    }

                    if (num == 1)
                    {
                        Console.Clear();
                        _users.LogIn();
                    }

                    if (num == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();

                        Console.WriteLine("Enter age");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter username");
                        string username = Console.ReadLine();

                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();

                        _users.AddUser(new Users()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Age = age,
                            Username = username,
                            Password = password
                        });
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully registered! \nPress any key to back to main menu");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        _users.ShowMainMenu();

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input.. Try again !!");
                    Console.ResetColor();
                    Console.Clear();
                    _users.ShowMainMenu();
                }
            }

        }
    }
}
