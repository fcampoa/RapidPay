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
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T FindById(int id);
        IEnumerable<T> Filter(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
    }
}
