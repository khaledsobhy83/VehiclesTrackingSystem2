using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace VTS.Repository
{
    /// <summary>
    /// Generic repository interface to be used in business logic
    /// It can be implemented by repositories for file, database or any other data source
    /// </summary>
    /// <typeparam name="T">Generic entity type</typeparam>
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
