using RockPaperScissiorsServices;
using RockPaperScissorsDomain.Classes;
using System;

namespace Rock_Paper_Scissors
{
class Program
{
static void Main(string[] args)
{
            UserServices userService = new UserServices();
            GameService gameService = new GameService();
            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("======== Welcom to RPS games ==========");
                    Console.WriteLine("Enter username");
                    string username = Console.ReadLine();
                    if (string.IsNullOrEmpty(username))
                    {
                        throw new Exception("You must enter username");
                    }

                    Player player = userService.GetPlayerByUserName(username);
                    Computer computer = new Computer();
                    Unsolved draw = new Unsolved();

                    if (player == null)
                    {
                        throw new Exception("The user does not exist");
                    }

                    bool passwordsMatch = userService.PasswordMatch(player.Password);
                    if (!passwordsMatch)
                    {
                        throw new Exception("Password did not match 3 times. Try again after 30min");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("==Successful login==");
                    Console.ResetColor();
                    while (true)
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("==Enter the option==");
                        Console.WriteLine("1)Play");
                        Console.WriteLine("2)Stats");
                        Console.WriteLine("3)Exit");
                        bool succ= int.TryParse(Console.ReadLine(), out int selection);
                        if (!succ)
                        {
                            throw new Exception("Pleas enter correct options!!!");
                        }
                        if (selection == 1)
                        {
                            gameService.Play(player,computer,draw);
                        }
                        else if (selection == 2)
                        {
                            gameService.Stats(player, computer,draw);
                        }
                        else if (selection == 3)
                        {
                            gameService.Exit();
                        }
                        else
                        {
                            throw new Exception("Pleas enter correct options!!!");
                        }

                        Console.WriteLine("=======================");
                        Console.WriteLine("Press enter to back to main menu");
                        Console.ReadLine();
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("User does not exist");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Incorrect input");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("An error occured");
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
