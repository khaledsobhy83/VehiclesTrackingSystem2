using System;
using System.Collections.Generic;
using System.Linq;
using VTS.Data.Sql;
using VTS.Helpers.Enums;
using VTS.Entity;
using System.Data.Entity;

namespace VTS.Repository
{
    /// <summary>
    /// Inherits the FileRepository methods and implements the vehicle specific methods in IVehicleRepository
    /// </summary>
    public class VehicleRepository : SqlRepository<Vehicle>,IVehicleRepository
    {
        public VehicleRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public IQueryable<Vehicle> GetAllVehicles()
        {
            return _dbContext.Set<Vehicle>().Where(v => v.IsDeleted == false && v.IsActive == true);
        }
        /// <summary>
        /// Returns vehicles by customer
        /// </summary>
        /// <param name="customerId"> The customer id where vehicle is associated with</param>
        /// <returns>Returns list of vehicles</returns>
        public IQueryable<Vehicle> GetVehiclesByCustomer(int customerId)
        {
            return GetAllVehicles().Where(v=> v.CustomerId == customerId);
        }
        /// <summary>
        /// Returns vehicles by status
        /// </summary>
        /// <param name="customerId"> Vehicle status</param>
        /// <returns>Returns list of vehicles</returns>
        public IQueryable<Vehicle> GetVehiclesByStatus(int status)
        {
            return GetAllVehicles().Where(v => v.VehicleStatus == status);
        }
        /// <summary>
        /// Returns vehicles by its Id
        /// </summary>
        /// <param name="vehicleId">Vehicle Id</param>
        /// <returns>Returns vehicle entity matching the specified id</returns>
        public Vehicle GetVehicleById(int vehicleId)
        {
            return _dbContext.Set<Vehicle>().Where(v => v.Id == vehicleId).FirstOrDefault();
        }

        /// <summary>
        /// Returns vehicle bu its VIN
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public Vehicle GetVehicleById(string vehicleId)
        {
            return _dbContext.Set<Vehicle>().Where(v => v.VIN == vehicleId).FirstOrDefault();
        }
        public IQueryable<Vehicle> SearchVehicles(int customerId, int status)
        {
            return GetAllVehicles().Where(v => v.CustomerId==customerId && v.VehicleStatus == status);
        }
        /// <summary>
        /// Updates spcific vehcile status
        /// </summary>
        /// <param name="vehicleId">The vehicle id to update its status</param>
        /// <param name="status">The new vehicle status</param>
        /// <returns>True if the vehcle status is updated successfully, false otherwise</returns>
        public bool UpdateVehicleStatus(Vehicle vehicle)
        {
            Update(vehicle);

            return _dbContext.SaveChanges() == 1;

        }

    }
}
