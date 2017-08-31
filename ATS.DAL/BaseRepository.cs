using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ATS.DAL.Contracts;

namespace ATS.DAL
{
    public class BaseRepository<T>:IBaseRepository<T> where T:class
    {
        protected DbContext db;

        public DbSet<T> Table {
            get { return db.Set<T>(); }
        }

        public BaseRepository(DbContext dbContext)
        {
            db = dbContext;
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            Table.AddOrUpdate(entity);
            return db.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public T GetById(long? id)
        {
            return Table.Find(id);
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}