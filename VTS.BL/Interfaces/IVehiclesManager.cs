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
    public interface IVehiclesManager
    {
        /// <summary>
        /// Returns all vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        List<Customer> GetAllVehicles();

        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        List<Customer> GetVehiclesByCustomer(int customerId);

        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        List<Customer> GetVehiclesByStatus(VehicleStatusEnum status);

        /// <summary>
        /// Updates spcific vehcile status
        /// </summary>
        /// <param name="vehicleId">The vehicle id to update its status</param>
        /// <param name="status">The new vehicle status</param>
        /// <returns>True if the vehcle status is updated successfully, false otherwise</returns>
        bool UpdateVehicleStatus(string vehicleId, VehicleStatusEnum status);
       
    }
}
