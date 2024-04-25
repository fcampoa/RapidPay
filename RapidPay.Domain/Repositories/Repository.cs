using Microsoft.EntityFrameworkCore;
using RapidPay.Domain.Models;
using System.Linq.Expressions;

namespace RapidPay.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> dbSet;
        public RapidPayContext DbContext { get; private set; }
        public Repository(RapidPayContext dbContext)
        {
            DbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public virtual T Create(T entity)
        {
            dbSet.Add(entity);
            DbContext.Entry<T>(entity).State = EntityState.Added;
            return entity;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual T FindById(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            DbContext.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
             return dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
