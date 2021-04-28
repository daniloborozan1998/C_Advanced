using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain.Classes
{
    public class Car : Vehicle
    {
        public int FuelTank { get; set; }
        public string Countries { get; set; }
        public Car(int id, string type, int yearOfProduction, int batchNumber,int fuelTank,string countries) : base(id, type, yearOfProduction, batchNumber)
        {
            FuelTank = fuelTank;
            Countries = countries;
        }

        public override void PrintVehicle()
        {
            Console.WriteLine("=== Car ====");
            Console.WriteLine($"The car is of the {Type} type and originates from {Countries}");
        }
    }
}
