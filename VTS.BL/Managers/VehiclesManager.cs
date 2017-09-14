using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles().ToList();
        }
        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Vehicle> GetVehiclesByCustomer(int customerId)
        {
            return _vehicleRepository.GetVehiclesByCustomer(customerId).ToList();
        }
        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        public List<Vehicle> GetVehiclesByStatus(VehicleStatusEnum status)
        {
            return _vehicleRepository.GetVehiclesByStatus((int)status).ToList();
        }
        /// <summary>
        /// Returns vehicles for specific customer and status
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="status">Vehicle status</param>
        /// <returns></returns>
        public List<Vehicle> SearchVehicles(int customerId, int status)
        {
            return _vehicleRepository.SearchVehicles(customerId, status).ToList();
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
                var vehicle = _vehicleRepository.GetVehicleById(vehicleId);

                if (vehicle == null)
                {
                    return false;
                }
                vehicle.VehicleStatus = (int)status;

                _vehicleRepository.UpdateVehicleStatus(vehicle);

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
