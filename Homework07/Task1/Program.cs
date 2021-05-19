using System;
using System.Collections.Generic;
using Task1.Exceptions;
using Task1.Services;


namespace Task1
{
    class Program
    {
        public static CalculateService _calculateService = new CalculateService();
        
        public static string Sum(double num1, double num2)
        {
            double result;
            result = num1 + num2;
            return $"{num1} + {num2} = {result}";

        }

        

        static void Main(string[] args)
        {
            try
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("======= Welcome =====");
                    Console.WriteLine("==Enter your first number =====");
                    bool succ = double.TryParse(Console.ReadLine(), out double number1);
                    Console.WriteLine("==Enter your second number =====");
                    bool succ2 = double.TryParse(Console.ReadLine(), out double number2);

                    if (succ && succ2)
                    {
                        Console.WriteLine($"{Sum(number1, number2)}");
                        _calculateService.Calculate($"{Sum(number1, number2)}");
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }
                    
                    Console.WriteLine("Do you want try again? y/n =====");
                    string again = Console.ReadLine();
                    if (again.ToLower() == "y")
                    {
                        flag = true;
                        Console.Clear();
                    }
                    else
                    {
                        flag = false;
                        Console.WriteLine("===== Goodbye =====");
                    }
                }
            }
            catch(Exception e)
            {
                _calculateService.Error("Exception",e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
