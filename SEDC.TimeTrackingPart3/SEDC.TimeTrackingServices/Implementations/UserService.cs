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
            
            _database = new FileDataBase<T>();
        }
        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            T userDb = _database.GetById(userId);
            if (userDb.Password != oldPassword)
            {
                MessageHelper.PrintMessage("Old passwords do not match", ConsoleColor.Red);
                
            }

            if (!ValidationHelper.ValidationPassword(newPassword))
            {
                MessageHelper.PrintMessage("Invalid password",ConsoleColor.Red);
                
            }

            userDb.Password = newPassword;
            _database.Update(userDb);
        }

        public void ChangeFirstName(int userId, string newFirstName)
        {
            T userDb = _database.GetById(userId);
            if (!ValidationHelper.ValidationFirstName(newFirstName))
            {
                MessageHelper.PrintMessage("The first name must be longer than 2 characters and not contain numbers", ConsoleColor.Red);
            }

            userDb.FirstName = newFirstName;
            _database.Update(userDb);
        }

        public void ChangeLastName(int userId, string newLastName)
        {
            T userDb = _database.GetById(userId);
            if (!ValidationHelper.ValidationFirstName(newLastName))
            {
                MessageHelper.PrintMessage("The last name must be longer than 2 characters and not contain numbers",ConsoleColor.Red);
            }

            userDb.LastName = newLastName;
            _database.Update(userDb);
        }

        public void DeactivateAccount(int userId)
        {
            T userDb = _database.GetById(userId);
            userDb.Id = userId;
            _database.RemoveById(userId);
            
            MessageHelper.PrintMessage("==== Goodbye",ConsoleColor.Green);
            MessageHelper.PrintMessage("Successfully deactivated",ConsoleColor.Green);
            
            Console.WriteLine("Press any key tok back to main menu");
            Console.ReadKey();
            Console.Clear();
            ShowMainMenu();

        }

        public void AddUser(T users)
        {
            if (!ValidationHelper.ValidationFirstName(users.FirstName))
            {
               MessageHelper.PrintMessage("Invalid firstname",ConsoleColor.Red);
            }
            if (!ValidationHelper.ValidationLastName(users.LastName))
            {
                MessageHelper.PrintMessage("Invalid lastname",ConsoleColor.Red);
            }
            if (!ValidationHelper.ValidationPassword(users.Password))
            {
                MessageHelper.PrintMessage("Invalid password", ConsoleColor.Red);
            }

            if (!ValidationHelper.ValidationUsername(users.Username))
            {
                MessageHelper.PrintMessage("Invalid username", ConsoleColor.Red);
            }
            if (!ValidationHelper.ValidationAge(users.Age))
            {
                MessageHelper.PrintMessage("Invalid age", ConsoleColor.Red);
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
                   
                    MessageHelper.PrintMessage($"User not found. Try again, you have {counter} more chances to hit.", ConsoleColor.Red);
                    
                    counter--;
                    flag = false;
                    if (counter == -1)
                    {
                        MessageHelper.PrintMessage("Goodbye. You don't have more chances to hit.", ConsoleColor.Red);
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
                    if (option < 1 || option > 5)
                    {
                        
                        MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                        
                        Console.Clear();
                        UserOptions();
                    }
                    if (option == 1)
                    {

                        Console.Clear();
                        AccountManagement();
                        bool success1 = int.TryParse(Console.ReadLine(), out int option1);
                        if (success1)
                        {
                            if (option1 < 1 || option1 > 4)
                            {
                                
                                MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                                
                                Console.Clear();
                                UserOptions();
                            }
                            if(option1 == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter your new password");
                                newPassword = Console.ReadLine();
                                ChangePassword(userId, password, newPassword);
                                MessageHelper.PrintMessage("Successfully changed password\nPress any key to back to option menu",ConsoleColor.Green);
                                Console.ReadKey();
                                Console.Clear();
                                UserOptions();
                            }
                            if(option1 == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter your new first name");
                                string firstname = Console.ReadLine();
                                ChangeFirstName(userId, firstname);
                                
                                MessageHelper.PrintMessage("Successfully changed first name \nPress any key to back to option menu",ConsoleColor.Green);
                                
                                Console.ReadKey();
                                Console.Clear();
                                UserOptions();
                            }
                            if(option1 == 3)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter your new last name");
                                string lastname = Console.ReadLine();
                                ChangeLastName(userId, newPassword);
                               
                                MessageHelper.PrintMessage("Successfully changed last name \nPress any key to back to option menu",ConsoleColor.Green);
                                
                                Console.ReadKey();
                                Console.Clear();
                                UserOptions();
                            }
                            if(option1 == 4)
                            {
                                Console.Clear();
                                BackOption();
                            }
                        }
                            

                    }
                    if (option == 2)
                    {

                        Console.Clear();
                        ShowActivities();
                        bool suc = int.TryParse(Console.ReadLine(), out int type);
                        if (suc)
                        {
                            if (type < 1 || type > 4)
                            {
                                
                                MessageHelper.PrintMessage("Wrong input.. try again ", ConsoleColor.Red);
                                
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
                                        
                                        MessageHelper.PrintMessage("Wrong input.. Try again", ConsoleColor.Red);
                                        
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You reading {ReadingTypes.BellesLettres} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.ReadingTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Enter how many pages you have read");
                                            bool suc1 = int.TryParse(Console.ReadLine(), out int page);
                                            if (suc1)
                                            {
                                                if (page < 1 || page > 145)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Wrong input.. Try again ");
                                                    Console.ResetColor();
                                                    Console.Clear();
                                                    UserOptions();
                                                }

                                                user.Page = page;

                                            }
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You reading {ReadingTypes.Fiction} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.ReadingTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Enter how many pages you have read");
                                            bool suc1 = int.TryParse(Console.ReadLine(), out int page);
                                            if (suc1)
                                            {
                                                if (page < 1 || page > 145)
                                                {
                                                    
                                                    MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                                                    
                                                    Console.Clear();
                                                    UserOptions();
                                                }

                                                user.Page = page;

                                            }
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You reading {ReadingTypes.ProfessionalLiterature} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.ReadingTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Enter how many pages you have read");
                                            bool suc1 = int.TryParse(Console.ReadLine(), out int page);
                                            if (suc1)
                                            {
                                                if (page < 1 || page > 145)
                                                {
                                                    
                                                    MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                                                    
                                                    Console.Clear();
                                                    UserOptions();
                                                }

                                                 user.Page = page;

                                            }
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
                                        
                                        MessageHelper.PrintMessage("Wrong input.. Try again", ConsoleColor.Red);
                                        
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You practice {ExercisingTypes.General} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.ExercisingTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You practice {ExercisingTypes.Running} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.ExercisingTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You practice {ExercisingTypes.Sport} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.ExercisingTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
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
                                    if (choose < 1 || choose > 2)
                                    {
                                        
                                        MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                                        
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You working at {WorkingTypes.Office} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.WorkingTimeOffice = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
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
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You working from {WorkingTypes.Home} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.WorkingTimeHome = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                }
                            }
                            if(type == 4)
                            {
                                Console.WriteLine("Choose type from hobbies list");
                                foreach (string t in Enum.GetNames(typeof(HobbiesType)))
                                {
                                    Console.WriteLine($"{count} {t}");
                                    count++;
                                }
                                bool finish = int.TryParse(Console.ReadLine(), out int choose);
                                if (finish)
                                {
                                    if (choose <= 1 || choose > 4)
                                    {
                                        
                                        MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                                        
                                        Console.Clear();
                                        UserOptions();
                                    }
                                    if (choose == 1)
                                    {
                                        T user = _database.GetById(userId);
                                        user.HobbiesTypes = HobbiesType.Football;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You play {HobbiesType.Football} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.HobbiesTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
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
                                        user.HobbiesTypes = HobbiesType.VideoGame;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            Console.WriteLine("===========================");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You play  {HobbiesType.VideoGame} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.HobbiesTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
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
                                        user.HobbiesTypes = HobbiesType.Basketball;
                                        Stopwatch stopwatch = new Stopwatch();
                                        stopwatch.Start();
                                        Console.WriteLine("Tracking is started... \nWhen you want to stop press enter");
                                        string enter = Console.ReadLine();
                                        if (enter == "")
                                        {
                                            stopwatch.Stop();
                                            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                                            
                                            Console.WriteLine("===========================");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You play  {HobbiesType.Basketball} {Convert.ToInt32(stopwatchElapsed.TotalSeconds)} seconds");
                                            user.HobbiesTime = Convert.ToInt32(stopwatchElapsed.TotalSeconds);
                                            Console.ResetColor();
                                            Console.WriteLine("===========================");
                                            Console.WriteLine("Press any key to back to option menu");
                                            Console.ReadKey();
                                            Console.Clear();
                                            UserOptions();
                                        }
                                    }
                                }
                            }
                            if(type == 5)
                            {
                                Console.Clear();
                                BackOption();
                            }
                        }
                        else
                        {
                            
                            MessageHelper.PrintMessage("Wrong input..  try again ", ConsoleColor.Red);
                            
                            Console.Clear();
                            UserOptions();
                        }

                    }

                    if (option == 3)
                    {
                        Console.Clear();
                        UserStatistics();
                        bool succ = int.TryParse(Console.ReadLine(), out int option2);
                        if (succ)
                        {
                            if (option2 < 1 || option2 > 6)
                            {
                                
                                MessageHelper.PrintMessage("Wrong input.. Try again ", ConsoleColor.Red);
                                
                                Console.Clear();
                                UserOptions();
                            }
                            if(option2 == 1)
                            {
                                Console.Clear();
                                AddingReading(userId);
                            }
                            if (option2 == 2)
                            {
                                Console.Clear();
                                AddingExercising(userId);
                            }
                            if (option2 == 3)
                            {
                                Console.Clear();
                                AddingWorking(userId);
                            }
                            if (option2 == 4)
                            {
                                Console.Clear();
                                AddingHobbies(userId);
                            }
                            if (option2 == 5)
                            {
                                Console.Clear();
                                Global(userId);
                                
                            }
                            if (option2 == 6)
                            {
                                Console.Clear();
                                BackOption();
                            }

                        }
                        

                    }
                    if (option == 4)
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
                    if (option == 5)
                    {
                        Console.Clear();
                        
                        MessageHelper.PrintMessage("You logged out \nPress any key for back to main menu", ConsoleColor.Green);
                        
                        Console.ReadKey();
                        Console.Clear();
                        flag1 = false;
                        ShowMainMenu();

                    }
                    
                }
                else
                {
                    
                    MessageHelper.PrintMessage("Wrong input.. try again ", ConsoleColor.Red);
                   
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
            Console.WriteLine("4)Hobbies");
            Console.WriteLine("5)Back to menu");
        }

        public void UserStatistics()
        {
            Console.Clear();
            Console.WriteLine("========== Activities Statistics ===========");
            Console.WriteLine("1)Reading ");
            Console.WriteLine("2)Exercising ");
            Console.WriteLine("3)Working");
            Console.WriteLine("4)Hobbies");
            Console.WriteLine("5)Global");
            Console.WriteLine("6)Back to menu");
        }

        public void UserOptions()
        {
            Console.WriteLine("Choose from this list");
            Console.WriteLine("==============");
            Console.WriteLine("1)AccountManagement ");
            Console.WriteLine("2)Activities for tracking ");
            Console.WriteLine("3)User Statistics ");
            Console.WriteLine("4)Deactivate account ");
            Console.WriteLine("5)LogOut");
            
        }

        public void AccountManagement()
        {
            Console.WriteLine("Choose from this list");
            Console.WriteLine("==============");
            Console.WriteLine("1) Change Password ");
            Console.WriteLine("2) Change First Name ");
            Console.WriteLine("3) Change Last Name ");
            Console.WriteLine("4) Back to menu ");
        }

        public void BackOption()
        {
            UserOptions();
        }


        public void AddingReading(int userId)
        {
            T users = _database.GetById(userId);
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{users.FirstName} {users.LastName} has {users.Age} years old. \nUsername: {users.Username} \nPassword: {users.Password}");
            if (users.ReadingTypes == ReadingTypes.BellesLettres)
            {
                Console.WriteLine($"Activity: Reading \nType: {ReadingTypes.BellesLettres} \nTime: {(users.ReadingTime/60)/60} hours \nPage: {users.Page}");
                
            }
            else if (users.ReadingTypes == ReadingTypes.Fiction)
            {
                Console.WriteLine($"Activity: Reading  \nType: {ReadingTypes.Fiction}  \nTime: {(users.ReadingTime/60)/60} hours \nPage: {users.Page}");
            }
            else if (users.ReadingTypes == ReadingTypes.ProfessionalLiterature)
            {
                Console.WriteLine($"Activity: Reading \nType: {ReadingTypes.ProfessionalLiterature} \nTime: {(users.ReadingTime / 60)/60} hours \nPage: {users.Page}");
            }
            Console.ResetColor();

            Console.WriteLine("Press any key to back to option menu");
            Console.ReadKey();
            Console.Clear();
            UserOptions();
        }

        public void AddingHobbies(int userId)
        {
            T users = _database.GetById(userId);
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{users.FirstName} {users.LastName} has {users.Age} years old. \nUsername: {users.Username} \nPassword: {users.Password}");
            if (users.HobbiesTypes == HobbiesType.Football)
            {
                Console.WriteLine($"Activity: Hobbies \nType: {HobbiesType.Football} \nTime: {users.HobbiesTime} seconds");
            }
            else if (users.HobbiesTypes == HobbiesType.Basketball)
            {
                Console.WriteLine($"Activity: Hobbies \nType: {HobbiesType.Basketball} \nTime: {users.HobbiesTime} seconds");
            }
            else if (users.HobbiesTypes == HobbiesType.VideoGame)
            {
                Console.WriteLine($"Activity: Hobbies \nType: {HobbiesType.VideoGame} \nTime: {users.HobbiesTime} seconds");
            }
            Console.ResetColor();

            Console.WriteLine("Press any key to back to option menu");
            Console.ReadKey();
            Console.Clear();
            UserOptions();
        }

        public void AddingWorking(int userId)
        {
            T users = _database.GetById(userId);
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{users.FirstName} {users.LastName} has {users.Age} years old. \nUsername: {users.Username} \nPassword: {users.Password} \n");
            Console.WriteLine($"Activity: Working \nType: {WorkingTypes.Office} \nHome Time: {(users.WorkingTimeOffice/60)/60} hours");
            Console.WriteLine($"Activity: Working \nType: {WorkingTypes.Home} \nOffice Time: {(users.WorkingTimeHome/60)/60} hours");
            Console.ResetColor();

            Console.WriteLine("Press any key to back to option menu");
            Console.ReadKey();
            Console.Clear();
            UserOptions();
        }

        public void AddingExercising(int userId)
        {
            T users = _database.GetById(userId);
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{users.FirstName} {users.LastName} has {users.Age} years old. \nUsername: {users.Username} \nPassword: {users.Password}");
            if (users.ExercisingTypes == ExercisingTypes.General)
            {
                Console.WriteLine($"Activity: Exercising \nType: {ExercisingTypes.General} \nTime: {users.ExercisingTime} seconds");
            }
            else if (users.ExercisingTypes == ExercisingTypes.Running)
            {
                Console.WriteLine($"Activity: Exercising \nType: {ExercisingTypes.Running} \nTime: {users.ExercisingTime} seconds");
            }
            else if (users.ExercisingTypes == ExercisingTypes.Sport)
            {
                Console.WriteLine($"Activity: Exercising \nType: {ExercisingTypes.Sport} \nTime: {users.ExercisingTime} seconds");
            }
            Console.ResetColor();

            Console.WriteLine("Press any key to back to option menu");
            Console.ReadKey();
            Console.Clear();
            UserOptions();
        }

        public void Global(int userId)
        {
            T users = _database.GetById(userId);
            Console.WriteLine("==========");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{users.FirstName} {users.LastName} has {users.Age} years old. \nUsername: {users.Username} \nPassword: {users.Password}");
            Console.WriteLine($"Total time of all activities: {((users.ExercisingTime + users.ReadingTime + users.HobbiesTime + users.WorkingTimeHome + users.WorkingTimeOffice)/60)/60} seconds");
            Console.ResetColor();

            Console.WriteLine("Press any key to back to option menu");
            Console.ReadKey();
            Console.Clear();
            UserOptions();
        }
    }
}
