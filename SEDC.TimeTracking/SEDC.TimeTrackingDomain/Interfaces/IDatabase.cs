using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingDomain.Interfaces
{
    public interface IDatabase<T> where T : IBaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void RemoveById(int id);
    }
}
