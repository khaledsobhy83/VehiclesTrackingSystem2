using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.DTO;
using VTS.Helpers.Enums;
namespace VTS.Entity
{
    public class Vehicle
    {
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

        private VehicleStatusEnum vehicleStatus;
        public VehicleStatusEnum VehicleStatus
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
