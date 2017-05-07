using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTS.FileStore
{
    /// <summary>
    /// This class acts as data entity, something like database table entity in entity framework
    /// </summary>
    [Serializable]
    public class CustomerStore
    {
        private int id;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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

        private string customerAddress;

        public string CustomerAddress
        {
            get
            {
                return customerAddress;
            }
            set
            {
                customerAddress = value;
            }
        }

        private List<VehicleStore> vehicles;

        public List<VehicleStore> Vehicles
        {
            get
            {
                return vehicles;
            }
            set
            {
                vehicles = value;
            }
        }

    }
}
