using System;
using System.Collections.Generic;

namespace ATS.DAL.Contracts
{
    public interface IBaseRepository<T>:IDisposable where T:class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(long? id);
        ICollection<T> GetAll();
    }
}
