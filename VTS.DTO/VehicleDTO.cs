using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Helpers.Enums;

namespace VTS.DTO
{
    public class VehicleDTO
    {

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
