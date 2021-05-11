using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Models;

namespace SEDC.TimeTrackingServices.Interfaces
{
    public interface ITrackService<T> where T:Track
    {
        void AddTrack(T track);
    }
}
