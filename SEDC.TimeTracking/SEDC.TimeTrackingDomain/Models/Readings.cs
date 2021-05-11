using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Enums;
using SEDC.TimeTrackingDomain.Interfaces;

namespace SEDC.TimeTrackingDomain.Models
{
    public class Readings : Track,IReading
    {
        public int Page { get; set; }
        public override void GetInfo()
        {
            Console.WriteLine($"Tittle: {Tittle} \n Descriptions: {Description} \n Page: {Page}");
        }

        public void AddTypes()
        {
            Readings.Add(ReadingTypes.BellesLettres);
            Readings.Add(ReadingTypes.Fiction);
            Readings.Add(ReadingTypes.ProfessionalLiterature);
        }

        public void PrintTypes()
        {
            foreach (ReadingTypes type in Readings)
            {
                Console.WriteLine(type);
            }
        }
    }
}
