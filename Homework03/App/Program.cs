using System;
using AppDomain;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========== Welcome =======");
            Console.WriteLine("=== List of vehicles === ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var vehicle in VehicleDB.Vehicles)
            {
                vehicle.PrintVehicle();
            }
            Console.ResetColor();
            Console.WriteLine("===============");
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[0]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[1]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[2]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[3]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[4]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[5]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[6]));
            Console.WriteLine(Validator.Validate(VehicleDB.Vehicles[7]));
            


            Console.ReadLine();
        }
    }
}
