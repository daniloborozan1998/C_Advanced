using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Interfaces;

namespace SEDC.TimeTrackingDomain.Models
{
    public  class Users : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double ReadingTime { get; set; }
        public double WorkingTimeOffice { get; set; }
        public double WorkingTimeHome { get; set; }
        public double ExercisingTime { get; set; }
        public double HobbiesTime { get; set; }
        public ReadingTypes ReadingTypes { get; set; }
        public int Page { get; set; }
        public ExercisingTypes ExercisingTypes { get; set; }
        public WorkingTypes WorkingTypes { get; set; }
        public HobbiesType HobbiesTypes { get; set; }


        public override void GetInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} has {Age} years old. \nUsername: {Username} \nPassword: {Password}");
        }
    }
}
