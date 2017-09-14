using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Helpers.Enums;

namespace VTS.DTO
{
    public class CustomerDTO
    {
        private long customerId;
        public long CustomerId
        {
            get
            {
                return customerId;
            }
            set
            {
                customerId = value;
            }
        }



        private string customerName;

        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
            }
        }

        
    }
}
