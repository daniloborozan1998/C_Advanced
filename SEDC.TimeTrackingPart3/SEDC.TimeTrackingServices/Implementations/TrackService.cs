using System;
using System.Collections.Generic;
using System.Text;
using SEDC.TimeTrackingDomain.Database;
using SEDC.TimeTrackingDomain.Interfaces;
using SEDC.TimeTrackingDomain.Models;
using SEDC.TimeTrackingServices.Interfaces;

namespace SEDC.TimeTrackingServices.Implementations
{
    public class TrackService<T> : ITrackService<T> where T : Track
    {
        private IDatabase<T> _database;

        public TrackService()
        {
            
            _database = new FileDataBase<T>();
        }
        public void AddTrack(T track)
        {
            _database.Insert(track);
        }
    }
}
