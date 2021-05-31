using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingDomain.Models
{
    public class Hobbies : Track,IHobbies
    {
        
        public void AddType()
        {
            Hobbies.Add(HobbiesType.Football);
            Hobbies.Add(HobbiesType.VideoGame);
            Hobbies.Add(HobbiesType.Basketball);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Tittle: {Tittle} \n Descriptions: {Description} \n");
        }

        public void PrintType()
        {
            foreach (HobbiesType type in Hobbies)
            {
                Console.WriteLine(type);
            }
        }
    }
}
