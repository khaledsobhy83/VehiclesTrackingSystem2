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
        IQueryable<Vehicle> GetAllVehicles();

        IQueryable<Vehicle> GetVehiclesByCustomer(int customerId);

        IQueryable<Vehicle> GetVehiclesByStatus(int status);

        IQueryable<Vehicle> SearchVehicles(int customerId, int status);

        Vehicle GetVehicleById(string vehicleId);

        bool UpdateVehicleStatus(Vehicle vehicle);
    }
}
