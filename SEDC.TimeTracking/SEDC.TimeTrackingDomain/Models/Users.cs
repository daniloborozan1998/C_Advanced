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
        public double Time { get; set; }
        public ReadingTypes ReadingTypes { get; set; }
        public ExercisingTypes ExercisingTypes { get; set; }
        public WorkingTypes WorkingTypes { get; set; }


        public override void GetInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} has {Age} years old. \nUsername: {Username} \nPassword: {Password}");
            if (ReadingTypes == ReadingTypes.BellesLettres)
            {
                Console.WriteLine($"Activity: Reading - Type: {ReadingTypes.BellesLettres} - Time: {Time} seconds"); ;
            }else if (ReadingTypes == ReadingTypes.Fiction)
            {
                Console.WriteLine($"Activity: Reading - Type: {ReadingTypes.Fiction} - Time: {Time} seconds");
            }
            else if(ReadingTypes == ReadingTypes.ProfessionalLiterature)
            {
                Console.WriteLine($"Activity: Reading \nType: {ReadingTypes.ProfessionalLiterature} \nTime: {Time} seconds"); 
            }
            else if(ExercisingTypes == ExercisingTypes.General)
            {
                Console.WriteLine($"Activity: Exercising \nType: {ExercisingTypes.General} \nTime: {Time} seconds"); 
            }
            else if (ExercisingTypes == ExercisingTypes.Running)
            {
                Console.WriteLine($"Activity: Exercising \nType: {ExercisingTypes.Running} \nTime: {Time} seconds");
            }
            else if (ExercisingTypes == ExercisingTypes.Sport)
            {
                Console.WriteLine($"Activity: Exercising \nType: {ExercisingTypes.Sport} \nTime: {Time} seconds");
            }
            else if (WorkingTypes == WorkingTypes.Office)
            {
                Console.WriteLine($"Activity: Working \nType: {WorkingTypes.Office} \nTime: {Time} seconds"); 
            }
            else if (WorkingTypes == WorkingTypes.Home)
            {
                Console.WriteLine($"Activity: Working \nType: {WorkingTypes.Home} \nTime: {Time} seconds"); 
            }
            else
            {
                Console.WriteLine("There is no such activity"); 
            }
            
        }
    }
}
