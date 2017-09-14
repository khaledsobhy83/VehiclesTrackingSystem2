using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTS.Entity;
using VTS.Helpers.Enums;
namespace VTS.Repository
{
    /// <summary>
    /// This interface has domain specifc methods other than those in the IRepository
    /// </summary>
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        /// <summary>
        /// Returns all active vehicles
        /// </summary>
        /// <returns></returns>
        IQueryable<Vehicle> GetAllVehicles();

        /// <summary>
        /// Returns vehciles for specific customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        IQueryable<Vehicle> GetVehiclesByCustomer(int customerId);

        /// <summary>
        /// Returns vehicles with specific status
        /// </summary>
        /// <param name="status">Vehicle status</param>
        /// <returns></returns>
        IQueryable<Vehicle> GetVehiclesByStatus(int status);

        /// <summary>
        /// Returns vehciles for specific customer and with specific status
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        IQueryable<Vehicle> SearchVehicles(int customerId, int status);

        /// <summary>
        /// Returns vehicle by its VIN
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        Vehicle GetVehicleById(string vehicleId);

        /// <summary>
        /// Updates vehicle status
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        bool UpdateVehicleStatus(Vehicle vehicle);
    }
}
