using System;
using System.Linq;
using laba2.Models;
using laba2.DB;
using System.Data.Entity;

namespace laba2.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private PersonalAccountManager context;
        private DbSet<T> dbSet;

        public Repository(PersonalAccountManager context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public int Add(T entity)
        {
            var addedEntity = dbSet.Add(entity);
            return addedEntity.Id;
        }

        public bool Delete(int id)
        {
            try
            {
                var deletedEntity = this.GetById(id);
                dbSet.Remove(deletedEntity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            return this.Delete(entity.Id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public int Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return entity.Id;
        }

        public void SaveChanged()
        {
            context.SaveChanges();
        }
    }
}