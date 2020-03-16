using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        void Add(T entity);
        void Delete(int id);
        void Remove(T entity);      
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>> orderedBy = null,
                             string includeProperties = null);

        T GetFirstOrDefault(
                            Expression<Func<T, bool>> filter = null,
                             string includeProperties = null);
            
    }
}
