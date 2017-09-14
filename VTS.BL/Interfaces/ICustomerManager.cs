using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Entity;

namespace VTS.BL
{
    public interface ICustomerManager
    {
        /// <summary>
        /// Returns all active and not deleted customers
        /// </summary>
        /// <returns>List of active customers</returns>
        List<Customer> GetAllCutomers();

    }
}
