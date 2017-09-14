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
        public static List<VehicleDTO> GetDTO(this List<Vehicle> vehiclesList)
        {
            List<VehicleDTO> vehicleList = new List<VehicleDTO>();

            foreach (Vehicle vehicle in vehiclesList)
            {
                vehicleList.Add(new VehicleDTO()
                {
                    CustomerName = vehicle.Customer.CustomerName,
                    RegistrationNo = vehicle.RegistrationNo,
                    VehicleId = vehicle.VIN,
                    VehicleStatus = vehicle.VehicleStatus.ToString()
                });
            }

            return vehicleList;
        }

        public static List<CustomerDTO> GetDTO(this List<Customer> customerList)
        {
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

            foreach (Customer customer in customerList)
            {
                customerDTOs.Add(new CustomerDTO()
                {
                    CustomerId = customer.Id,
                    CustomerName = customer.CustomerName
                });
            }

            return customerDTOs;
        }
    }
}
