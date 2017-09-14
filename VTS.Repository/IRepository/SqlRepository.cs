using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTS.Data.Sql;

namespace VTS.Repository
{
    /// <summary>
    /// Generic SQL Server implementation of IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _dbContext;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Deletes specific entity from database
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        /// <summary>
        /// Returns all records from specific entity
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable<T>();
        }
        /// <summary>
        /// Retruns entity by its Id
        /// </summary>
        /// <param name="id">The primary key of the entity</param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        /// <summary>
        /// Inserts new entity to the database
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        /// <returns></returns>
        public T Insert(T entity)
        {
            return _dbContext.Set<T>().Add(entity);
        }
        /// <summary>
        /// Marks and entity as uodated to be considered by SaveChanges
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public void Update(T entity)
        {
            _dbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
