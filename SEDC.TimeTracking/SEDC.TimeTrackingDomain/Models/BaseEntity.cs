using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Interfaces;

namespace SEDC.TimeTrackingDomain.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public abstract void GetInfo();
    }
}
