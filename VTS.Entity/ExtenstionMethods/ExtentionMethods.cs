using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.DTO;
using VTS.Helpers.Enums;
namespace VTS.Entity
{
    public static class ExtentionMethods
    {
        public static List<VehicleDTO> GetDTO(this List<Customer> customerList)
        {
            List<VehicleDTO> vehicleList = new List<VehicleDTO>();

            foreach( Customer customerentity in customerList)
            {
                foreach (Vehicle vehicle in customerentity.Vehicles)
                {
                    vehicleList.Add(new VehicleDTO()
                    {
                        CustomerName = customerentity.CustomerName,
                        RegistrationNo = vehicle.RegistrationNo,
                        VehicleId = vehicle.VehicleId,
                        VehicleStatus = vehicle.VehicleStatus == VehicleStatusEnum.Offline ? "Offline" : "Online"
                    });
                }
            }

            
            return vehicleList;
        }
    }
}
