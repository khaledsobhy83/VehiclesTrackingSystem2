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
    public class VehicleStore
    {
        private int customerId;
        public int CustomerId
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

        private string vehicleId;
        public string VehicleId
        {
            get
            {
                return vehicleId;
            }
            set
            {
                vehicleId = value;
            }
        }

        private string registrationNo;
        public string RegistrationNo
        {
            get
            {
                return registrationNo;
            }
            set
            {
                registrationNo = value;
            }
        }

        private string vehicleStatus;
        public string VehicleStatus
        {
            get
            {
                return vehicleStatus;
            }
            set
            {
                vehicleStatus = value;
            }
        }
    }
}
