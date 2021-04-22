using System;
using WorkingDaysServices;

namespace WorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            Services newDataServices = new Services();
            bool answer = true;
            while (answer)
            {
                try
                {
                    Console.WriteLine("Enter day from 1 to 31)");
                    bool succ = int.TryParse(Console.ReadLine(), out int days);
                    Console.WriteLine("Enter month from 1  to 12");
                    bool succ1 = int.TryParse(Console.ReadLine(), out int month);
                    Console.WriteLine("Enter year from 1999 to 2021");
                    bool succ2 = int.TryParse(Console.ReadLine(), out int year);
                    
                    if (succ && succ1 && succ2)
                    {
                        newDataServices.GetData(year, month, days);
                    }
                    else
                    {
                        throw new Exception("Wrong input. Must be number.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Incorrect input");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Do you want to check other date? y/n");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "y")
                {
                    answer = true;
                    Console.Clear();
                    
                }
                else
                {
                    answer = false;
                    Console.WriteLine("===Goodbye===");
                }
            }


            Console.ReadLine();
        }
    }
}
