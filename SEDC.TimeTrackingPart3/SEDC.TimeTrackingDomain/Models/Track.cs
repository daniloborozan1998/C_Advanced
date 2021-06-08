using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Enums;

namespace SEDC.TimeTrackingDomain.Models
{
    public abstract class Track : BaseEntity
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }

        public List<ReadingTypes> Readings { get; set; }
        public List<ExercisingTypes> Exercisings { get; set; }
        public List<WorkingTypes> Workings { get; set; }
        public List<HobbiesType> Hobbies { get; set; }
        



        public Track()
        {
            Readings = new List<ReadingTypes>();
            Exercisings = new List<ExercisingTypes>();
            Workings = new List<WorkingTypes>();
        }
    }
}
