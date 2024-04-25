using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Domain.Repositories
{
    public interface IRepository<T>
    {
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public List<T> GetAll();
        public T FindById(int id);
        public IEnumerable<T> Filter(Expression<Func<T, bool>> where);
        public T Get(Expression<Func<T, bool>> where);
    }
}
