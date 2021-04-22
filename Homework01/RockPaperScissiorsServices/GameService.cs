using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain;
using RockPaperScissorsDomain.Classes;
using RockPaperScissorsDomain.Enums;

namespace RockPaperScissiorsServices
{
    public class GameService
    {
        public  void Play(Player player, Computer computer,Unsolved draw)
        {
            List<Role> roles = new List<Role>()
            {
                Role.Rock,
                Role.Paper,
                Role.Scissors
            };
            Console.WriteLine("======Let's play RPS==========");
            Console.WriteLine("==Options==");
            foreach (var options in roles)
            {
                Console.WriteLine(options);   
            }
            Console.WriteLine("====================");
            Console.WriteLine("Enter your choice:");
            string playerChoice = Console.ReadLine().ToUpper();
            Random random = new Random();
            int n = random.Next(1, 3);
            Console.WriteLine("====================");
            Console.WriteLine($"Player: {playerChoice}");
            Console.WriteLine("Computer:" + roles[n]);
            Console.WriteLine("=====================");
            Console.Write("Result:");

            if (string.IsNullOrEmpty(playerChoice))
            {
                throw new Exception("You must select at least one of the offered options");
            }

            if (playerChoice == "ROCK" && roles[n] == Role.Scissors)
            {
                Console.WriteLine("Congratulations, you have won this round. ROCK beats SCISSOR");
                player.Wins++;
                computer.Games++;
            }
            else if (playerChoice == "ROCK" && roles[n] == Role.Paper)
            {
                Console.WriteLine("Computer wins. PAPER beats ROCK");
                Console.WriteLine("Maybe you will have better luck next time.");
                computer.Wins++;
                computer.Games++;
            }
            else if (playerChoice == "PAPER" && roles[n] == Role.Rock)
            {
                Console.WriteLine("Congratulations, you have won this round. PAPER beats ROCK");
                player.Wins++;
                computer.Games++;
            }
            else if (playerChoice == "PAPER" && roles[n] == Role.Scissors)
            {
                Console.WriteLine("Computer Wins. SCISSOR beats PAPER");
                Console.WriteLine("Maybe you will have better luck next time.");
                computer.Wins++;
                computer.Games++;
            }
            else if (playerChoice == "SCISSORS" && roles[n] == Role.Rock)
            {
                Console.WriteLine("Computer Wins. ROCK beats SCISSOR");
                Console.WriteLine("Maybe you will have better luck next time.");
                computer.Wins++;
                computer.Games++;
            }
            else if (playerChoice == "SCISSORS" && roles[n] == Role.Paper)
            {
                Console.WriteLine("Congratulations, you have won this round. SCISSOR beats PAPER");
                player.Wins++;
                computer.Games++;
            }
            else if(playerChoice == "PAPER" && roles[n] == Role.Paper )
            {
                Console.WriteLine("Same choices");
                draw.Draw++;
                computer.Games++;
            }else if (playerChoice == "SCISSORS" && roles[n] == Role.Scissors)
            {
                Console.WriteLine("Same choices");
                draw.Draw++;
                computer.Games++;
            }
            else if (playerChoice == "ROCK" && roles[n] == Role.Rock)
            {
                Console.WriteLine("Same choices");
                draw.Draw++;
                computer.Games++;
            }
            else
            {
                throw new Exception("Pleas enter correct options!!!");
            }
            

        }

        public  void Stats(Player player, Computer computer,Unsolved draw)
        {
            Console.WriteLine("======STATISTICS=======");
            Console.WriteLine($"All games {computer.Games}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User wins: {player.Wins}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Computer wins: {computer.Wins}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"A draw : {draw.Draw}");
            Console.ResetColor();

            Console.WriteLine("========================");
            Console.WriteLine("User results in percentage");

            int percentWins = (int)Math.Round((double)(100 * player.Wins) / computer.Games);
            int percentLosses = 100 - (percentWins);
            Console.WriteLine($"All games {computer.Games}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Wins {percentWins}%");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Losses {percentLosses}%");
            Console.ResetColor();
        }

        public void Exit()
        {
            System.Environment.Exit(-1);
        }
    }
}
