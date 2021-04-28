using System;
using System.Collections.Generic;
using System.Text;
using AppDomain.Classes;

namespace AppDomain
{
    public class Validator
    {
        public static bool Validate(Vehicle v)
        {
            if (v.Id > 0 && !string.IsNullOrEmpty(v.Type) && v.YearOfProduction > 0)
            {
                Console.WriteLine("==== Everything is fine");
                return true;
            }
            else
            {
                Console.WriteLine("==== Id must be greater than zero, Type is not empty and year of production must be greater than zero");
                return false;
            }
        }
    }
}
