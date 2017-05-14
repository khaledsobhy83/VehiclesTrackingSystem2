using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Entity;
using VTS.FileStore;
using AutoMapper;
using VTS.Helpers.Enums;
namespace VTS.Repository
{
    /// <summary>
    /// Inherits the FileRepository methods and implements the vehicle specific methods in IVehicleRepository
    /// </summary>
    public class VehicleRepository : FileRepository<Vehicle>,IVehicleRepository
    {
        
        public List<Customer> GetAllVehicles()
        {
            var vehiclesList = VehicleSystemFileStore.CustomersVehicles.ToList();
            
            return Mapper.Map<List<Customer>>(vehiclesList);
        }
        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Customer> GetVehiclesByCustomer(int customerId)
        {
            var vehiclesList = VehicleSystemFileStore.CustomersVehicles.Where(c => c.ID == customerId).ToList();

            return Mapper.Map<List<Customer>>(vehiclesList);
        }
        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Customer> GetVehiclesByStatus(VehicleStatusEnum status)
        {
            var statusString = Enum.GetName(status.GetType(), status);

            var vehiclesList = VehicleSystemFileStore.CustomersVehicles.Where(v => v.Vehicles.Any(x => x.VehicleStatus == statusString)).
                Select
                (c => new CustomerStore
                {
                    CustomerAddress = c.CustomerAddress,
                    ID = c.ID,
                    CustomerName = c.CustomerName,
                    Vehicles = c.Vehicles.Where(s => s.VehicleStatus == statusString).ToList()
                }).ToList();

            return Mapper.Map<List<Customer>>(vehiclesList);
        }
        /// <summary>
        /// Returns vehicles by its Id
        /// </summary>
        /// <param name="vehicleId">Vehicle Id</param>
        /// <returns>Returns vehicle entity matching the specified id</returns>
        public Vehicle GetVehicleById(string vehicleId)
        {
            var vehiclesList = VehicleSystemFileStore.CustomersVehicles.Select
                (c => c.Vehicles.Where(s => s.VehicleId == vehicleId)).SingleOrDefault();

            return Mapper.Map<List<Vehicle>>(vehiclesList).SingleOrDefault();
        }
        /// <summary>
        /// Updates spcific vehcile status
        /// </summary>
        /// <param name="vehicleId">The vehicle id to update its status</param>
        /// <param name="status">The new vehicle status</param>
        /// <returns>True if the vehcle status is updated successfully, false otherwise</returns>
        public void UpdateVehicleStatus(string vehicleId, VehicleStatusEnum status)
        {
            VehicleSystemFileStore.CustomersVehicles.Select
                (c => c.Vehicles.Where(s => s.VehicleId == vehicleId)).SingleOrDefault().ToList().ForEach(x => { x.VehicleStatus = "Online"; }); ;
            
            VehicleSystemFileStore.SerializeCollection();
        }

    }
}
