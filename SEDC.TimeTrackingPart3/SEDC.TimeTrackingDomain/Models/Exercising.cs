using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Interfaces;

namespace SEDC.TimeTrackingDomain.Models
{
    public class Exercising : Track,IExercising
    {
        
        public override void GetInfo()
        {
            Console.WriteLine($"Tittle: {Tittle} \n Descriptions: {Description}"); 
        }

        public void AddType()
        {
            Exercisings.Add(ExercisingTypes.General);
            Exercisings.Add(ExercisingTypes.Running);
            Exercisings.Add(ExercisingTypes.Sport);
        }

        public void PrintType()
        {
            foreach (ExercisingTypes type in Exercisings)
            {
                Console.WriteLine(type);
            }
        }
    }
}
