using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Interfaces;

namespace SEDC.TimeTrackingDomain.Models
{
    public class Working : Track,IWorking
    {
        public double WorkingHoursFromOffice { get; set; }
        public double WorkingHoursFromHome { get; set; }
       
        public override void GetInfo()
        {
            Console.WriteLine($"Tittle: {Tittle} \n Descriptions: {Description} \n");
        }

        public void AddTypes()
        {
            Workings.Add(WorkingTypes.Home);
            Workings.Add(WorkingTypes.Office);
        }

        public void PrintTypes()
        {
            foreach (WorkingTypes type in Workings)
            {
               Console.WriteLine(type);
            }
        }
    }
}
