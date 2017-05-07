using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Entity;
using VTS.Helpers.Enums;
using VTS.Repository;

namespace VTS.BL
{
    public class VehiclesManager : IVehiclesManager
    {
        private IVehicleRepository _vehicleRepository;
        public VehiclesManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        /// <summary>
        /// Returns all vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Customer> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }
        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Customer> GetVehiclesByCustomer(int customerId)
        {
            return _vehicleRepository.GetVehiclesByCustomer(customerId);
        }
        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Customer> GetVehiclesByStatus(VehicleStatusEnum status)
        {
            return _vehicleRepository.GetVehiclesByStatus(status);
        }
        /// <summary>
        /// Updates spcific vehcile status
        /// </summary>
        /// <param name="vehicleId">The vehicle id to update its status</param>
        /// <param name="status">The new vehicle status</param>
        /// <returns>True if the vehcle status is updated successfully, false otherwise</returns>
        public bool UpdateVehicleStatus(string vehicleId, VehicleStatusEnum status)
        {
            try
            {
                _vehicleRepository.UpdateVehicleStatus(vehicleId, status);

                return true;
            }
            catch(Exception ex)
            {
                //TODO: log the exception
                return false;
            }
        }
    }
}
