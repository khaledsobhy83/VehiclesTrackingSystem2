using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Entity;
using VTS.Repository;

namespace VTS.BL
{
    public class CustomerManager : ICustomerManager
    {
        private ICustomerRepository _repository;
        public CustomerManager(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public List<Customer> GetAllCutomers()
        {
            return _repository.GetAllCustomers().ToList();
        }
    }
}
