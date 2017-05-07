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
    public interface IVehicleRepository
    {
        List<Customer> GetAllVehicles();

        List<Customer> GetVehiclesByCustomer(int customerId);

        List<Customer> GetVehiclesByStatus(VehicleStatusEnum status);

        Vehicle GetVehicleById(string vehicleId);

        void UpdateVehicleStatus(string vehicleId, VehicleStatusEnum status);
    }
}
