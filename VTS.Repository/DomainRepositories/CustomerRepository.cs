using System;
using System.Collections.Generic;
using System.Linq;
using VTS.Data.Sql;
using System.Linq.Expressions;
using VTS.Entity;
using System.Data.Entity;

namespace VTS.Repository
{
    /// <summary>
    /// Inherits the FileRepository methods and implements the vehicle specific methods in IVehicleRepository
    /// </summary>
    public class CustomerRepository : SqlRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _dbContext.Set<Customer>().Where(c => c.IsDeleted == false && c.IsActive==true);
        }
    }
}
