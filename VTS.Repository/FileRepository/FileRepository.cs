using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VTS.Entity;
using VTS.FileStore;
using AutoMapper;
using VTS.Helpers.Enums;


namespace VTS.Repository
{
    /// <summary>
    /// File datasurce repository for IRepository interface
    /// </summary>
    /// <typeparam name="T">Generic entity type</typeparam>
    public class FileRepository<T> : IRepository<T> where T : class
    {
        public FileRepository()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<CustomerStore, Customer>();
                cfg.CreateMap<VehicleStore, Vehicle>();
            });
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
