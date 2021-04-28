using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Classes
{
    public class Bike : Vehicle
    {
        public string Color { get; set; }
        public Bike(int id, string type, int yearOfProduction, int batchNumber,string color) : base(id, type, yearOfProduction, batchNumber)
        {
            Color = color;
        }

        public override void PrintVehicle()
        {
            Console.WriteLine("=== Bike ===");
            Console.WriteLine($"The bike was produced in {YearOfProduction} and is {Color}");
        }
    }
}
