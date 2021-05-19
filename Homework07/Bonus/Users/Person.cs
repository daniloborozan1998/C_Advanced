using System;
using System.Collections.Generic;
using System.Text;

namespace Bonus.Users
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        public string PrintPerson()
        {
           return $"{FirstName} {LastName} {Age}";
        }
    }
}
