using System;
using System.Collections.Generic;
using System.Text;
using AppDomain.Classes;

namespace AppDomain
{
    public class VehicleDB
    {
        public static List<Vehicle> Vehicles { get; set; }

        static VehicleDB()
        {
            Vehicles = new List<Vehicle>()
            {
                new Car(0,"Golf",2008,161025,60,"Germany"),
                new Car(2,"Renault",2004,125088,45,"France"),
                new Car(3,"AUDI",2013,325668,65,"Germany"),
                new Car(4,"Ferrari ",2021,556846,70,"Italy"),
                new Bike(5,"Road bikes",2020,558996,"white"),
                new Bike(6,"Mountain bikes",2021,369258,"red"),
                new Bike(7,"Folding bikes",2019,26584521,"black"),
                new Bike(8,"Cyclocross bikes",2015,357159,"gray")
            };
        }
    }
}
