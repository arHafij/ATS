using System.Collections.Generic;

namespace ATS.BLL.Contracts
{
    public interface IManager<T> where T:class
    {
        bool Add(T entity);
        bool Add(ICollection<T> entities);
        bool Remove(T entity);
        bool Update(ICollection<T> entities);
        bool Update(T entity);

        T GetById(long? id);
        ICollection<T> GetAll();
    }
}
