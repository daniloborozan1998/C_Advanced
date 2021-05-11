using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using SEDC.TimeTrackingDomain.Database;
using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Interfaces;
using SEDC.TimeTrackingDomain.Models;
using SEDC.TimeTrackingServices.Helpers;
using SEDC.TimeTrackingServices.Interfaces;

namespace SEDC.TimeTrackingServices.Implementations
{
    public class UserService<T> : IUserService<T> where T : Users
    {
        private IDatabase<T> _database;

        public UserService()
        {
            _database = new Database<T>();
        }
        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            T userDb = _database.GetById(userId);
            if (userDb.Password != oldPassword)
            {
                throw new Exception("Old passwords do not match");
            }

            if (!ValidationHelper.ValidationPassword(newPassword))
            {
                throw new Exception("Invalid password");
            }

            userDb.Password = newPassword;
            _database.Update(userDb);
        }

        public void ChangeFirstName(int userId, string newFirstName)
        {
            T userDb = _database.GetById(userId);
            if (!ValidationHelper.ValidationFirstName(newFirstName))
            {
                throw new Exception("The first name must be longer than 2 characters and not contain numbers");
            }

            userDb.FirstName = newFirstName;
            _database.Update(userDb);
        }

        public void ChangeLastName(int userId, string newLastName)
        {
            T userDb = _database.GetById(userId);
            if (!ValidationHelper.ValidationFirstName(newLastName))
            {
                throw new Exception("The last name must be longer than 2 characters and not contain numbers");
            }

            userDb.LastName = newLastName;
            _database.Update(userDb);
        }

        public void DeactivateAccount(int userId)
        {
            T userDb = _database.GetById(userId);
            userDb.Id = userId;
            _database.RemoveById(userId);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("==== Goodbye");
            Console.WriteLine("Successfully deactivated");
            Console.ResetColor();
            Console.WriteLine("Press any key tok back to main menu");
            Console.ReadKey();
            Console.Clear();
            ShowMainMenu();

        }

        public void AddUser(T users)
        {
            if (!ValidationHelper.ValidationFirstName(users.FirstName))
            {
                throw new Exception("Invalid firstname");
            }
            if (!ValidationHelper.ValidationLastName(users.LastName))
            {
                throw new Exception("Invalid lastname");
            }
            if (!ValidationHelper.ValidationPassword(users.Password))
            {
                throw new Exception("Invalid password");
            }

            if (!ValidationHelper.ValidationUsername(users.Username))
            {
                throw new Exception("Invalid username");
            }
            if (!ValidationHelper.ValidationAge(users.Age))
            {
                throw new Exception("Invalid age");
            }
            _database.Insert(users);

        }

        string username;
        string password;
        string newPassword;
        int userId;
        public void LogIn()
        {
            
            List<T> userDb = _database.GetAll();
            int counter = 2;
            bool flag = false;
            while (flag == false)
            {

                Console.WriteLine("Enter username");
                username = Console.ReadLine();
                Console.WriteLine("Enter password");
                password = Console.ReadLine();

                bool findUser = userDb.Any(x => x.Username == username && x.Password == password);
                if (findUser == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"User not found. Try again, you have {counter} more chances to hit.");
                    Console.ResetColor();
                    counter--;
                    flag = false;
                    if (counter == -1)
                    {
                        Console.WriteLine("Goodbye. You don't have more chances to hit.");
                        Console.ReadKey();
                        Environment.Exit(-1);
                    }
                }
                else
                {
                    Console.Clear();
                    List<T> users = _database.GetAll();
                    List<int> idUser = userDb.Where(x => x.Username == username && x.Password == password).Select(x => x.Id).ToList();
                    foreach (int u in idUser)
                    {
                        T user = _database.GetById(u);
                        userId = user.Id;
                    }

                    T currentUser = _database.GetById(userId);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Hello {currentUser.FirstName} {currentUser.LastName} \nWhat do you want to do?");
                    Console.ResetColor();
                    Console.WriteLine("================");
                    flag = true;
                }
            }

            UserOptions();
            bool flag1 = true;
            while (flag1 == true)
            {
                bool success = int.TryParse(Console.ReadLine(), out int option);
                if (success)
                {
                    if (option < 1 || option > 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input.. Try again ");
                        Console.ResetColor();
                        Console.Clear();
                        UserOptions();
                    }
                    if (option == 1)
                    {

                        Console.Clear();
                        Console.WriteLine("Enter your new password");
                        newPassword = Console.ReadLine();
                        ChangePassword(userId, password, newPassword);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully changed password\nPress any key to back to option menu");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        UserOptions();

                    }
                    if (option == 2)
                    {

                        Console.Clear();
                        Console.WriteLine("Enter your new first name");
                        string firstname = Console.ReadLine();
                        ChangeFirstName(userId, firstname);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully changed first name \nPress any key to back to option menu");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        UserOptions();

                    }

                    if (option == 3)
                    {
                        Console.WriteLine("Enter your new last name");
                        string lastname = Console.ReadLine();
                        ChangeLastName(userId,newPassword);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully changed last name \nPress any key to back to option menu");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        UserOptions();
                    }
                    if (option == 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You logged out \nPress any key for back to main menu");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                        flag1 = false;
                        ShowMainMenu();
                    }
                    if (option == 5)
                    {
                        Console.Clear();
                        ShowActivities();
                        bool suc = int.TryParse(Console.ReadLine(), out int type);
                        if (suc)
                        {
                            if (type < 1 || type > 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong input.. try again ");
                                Console.ResetColor();
                                Console.Clear();
                                UserOptions();
                            }
                            int count = 1;
                            if (type == 1)
                            {
                                Console.WriteLine("Choose type from reading list");
                                foreach (string t in Enum.GetNames(typeof(ReadingTypes)))
                                {
                                    Console.WriteLine($"{count} {t}");
                                    count++;
                                }
                                bool finish = int.TryParse(Console.ReadLine(), out int choose);
                                if (finish)
                                {
                                    if (choose < 1 || choose > 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input.. Try again");
                                        Console.ResetColor();
                                        Console.Clear();
                                        UserOptions();
                                    }
                                    if (choose == 1)
                                    {
                                        T user = _database.GetById(userId);
                                        user.ReadingTypes = ReadingTypes.BellesLettres;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You reading {ReadingTypes.BellesLettres} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                    if (choose == 2)
                                    {
                                        T user = _database.GetById(userId);
                                        user.ReadingTypes = ReadingTypes.Fiction;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You reading {ReadingTypes.Fiction} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                    if (choose == 3)
                                    {
                                        T user = _database.GetById(userId);
                                        user.ReadingTypes = ReadingTypes.ProfessionalLiterature;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You reading {ReadingTypes.ProfessionalLiterature} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Wrong input.. Try again");
                                    Console.ResetColor();
                                    Console.Clear();
                                    UserOptions();
                                }
                            }
                            if (type == 2)
                            {
                                Console.WriteLine("Choose type from exercising list");
                                foreach (string t in Enum.GetNames(typeof(ExercisingTypes)))
                                {
                                    Console.WriteLine($"{count} {t}");
                                    count++;
                                }
                                bool finish = int.TryParse(Console.ReadLine(), out int choose);
                                if (finish)
                                {
                                    if (choose < 1 || choose > 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input.. Try again");
                                        Console.ResetColor();
                                        Console.Clear();
                                        UserOptions();
                                    }
                                    if (choose == 1)
                                    {
                                        T user = _database.GetById(userId);
                                        user.ExercisingTypes = ExercisingTypes.General;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You practice {ExercisingTypes.General} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                    if (choose == 2)
                                    {
                                        T user = _database.GetById(userId);
                                        user.ExercisingTypes = ExercisingTypes.Running;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You practice {ExercisingTypes.Running} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                    if (choose == 3)
                                    {
                                        T user = _database.GetById(userId);
                                        user.ExercisingTypes = ExercisingTypes.Sport;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You practice {ExercisingTypes.Sport} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                }
                            }
                            if (type == 3)
                            {
                                Console.WriteLine("Choose type from working list");
                                foreach (string t in Enum.GetNames(typeof(WorkingTypes)))
                                {
                                    Console.WriteLine($"{count} {t}");
                                    count++;
                                }
                                bool finish = int.TryParse(Console.ReadLine(), out int choose);
                                if (finish)
                                {
                                    if (choose < 1 || choose > 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong input.. Try again ");
                                        Console.ResetColor();
                                        Console.Clear();
                                        UserOptions();
                                    }
                                    if (choose == 1)
                                    {
                                        T user = _database.GetById(userId);
                                        user.WorkingTypes = WorkingTypes.Office;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You working at {WorkingTypes.Office} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                    if (choose == 2)
                                    {
                                        T user = _database.GetById(userId);
                                        user.WorkingTypes = WorkingTypes.Home;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.WriteLine($"You working from {WorkingTypes.Home} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.Time = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input..  try again ");
                            Console.ResetColor();
                            Console.Clear();
                            UserOptions();
                        }
                    }
                    if (option == 6)
                    {
                        T user = _database.GetById(userId);
                        Console.Clear();
                        Console.WriteLine("Do you want to deactivate account (yes or no)");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() == "yes")
                        {
                            DeactivateAccount(userId);
                        }
                        else if (answer.ToLower() == "no")
                        {
                            Console.Clear();
                            Console.WriteLine("Press any key to back to option menu");
                            Console.ReadKey();
                            Console.Clear();
                            UserOptions();
                        }
                    }
                    if (option == 7)
                    {
                        Console.Clear();
                        UserStatistics(userId);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input.. try again ");
                    Console.ResetColor();
                    Console.Clear();
                    UserOptions();
                }
            }
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("========== WELCOME TO TIME TRACKING APP ===========");
            Console.WriteLine("Choose option");
            Console.WriteLine("1)Log in");
            Console.WriteLine("2)Register");
        }

        public void ShowActivities()
        {
            Console.Clear();
            Console.WriteLine("========== Activities ===========");
            Console.WriteLine("1)Reading ");
            Console.WriteLine("2)Exercising ");
            Console.WriteLine("3)Working");
        }

        public void UserStatistics(int userId)
        {
            T users = _database.GetById(userId);
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            users.GetInfo();
            Console.ResetColor();

            Console.WriteLine("Press any key to back to option menu");
            Console.ReadKey();
            Console.Clear();
            UserOptions();
        }

        public void UserOptions()
        {
            Console.WriteLine("Choose from this list");
            Console.WriteLine("==============");
            Console.WriteLine("1) Change Password ");
            Console.WriteLine("2) Change First Name ");
            Console.WriteLine("3) Change Last Name ");
            Console.WriteLine("4)LogOut");
            Console.WriteLine("5)Activities for tracking ");
            Console.WriteLine("6)Deactivate account ");
            Console.WriteLine("7)User Statistics ");
           
        }
    }
}
