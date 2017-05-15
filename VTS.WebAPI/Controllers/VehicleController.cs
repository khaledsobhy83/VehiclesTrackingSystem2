using System.Collections.Generic;
using System.Web.Http;
using VTS.BL;
using VTS.Entity;
using VTS.Helpers;
using VTS.Helpers.Enums;
using VTS.DTO;
using System.Web.Http.Cors;

namespace VTS.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8415", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        private IVehiclesManager _vehiclesManager;

        public VehicleController(IVehiclesManager vehiclesManager)
        {
            _vehiclesManager = vehiclesManager;
        }

        // GET api/<controller>
        public IEnumerable<VehicleDTO> Get()
        {
            return _vehiclesManager.GetAllVehicles().GetDTO();
        }

        // GET api/<controller>/5
        public IEnumerable<VehicleDTO> GetByCustomer(int id)
        {
            return _vehiclesManager.GetVehiclesByCustomer(id).GetDTO();
        }
        // GET api/<controller>/<action>/5
        public IEnumerable<VehicleDTO> GetByStatus(int id)
        {
            return _vehiclesManager.GetVehiclesByStatus((VehicleStatusEnum)id).GetDTO();
        }
       
        // POST api/<controller>
        [HttpPost]
        public bool UpdateMyStatus(VehicleStatus vehicleStatus)
        {
            if(vehicleStatus.status > 1)
            {
                return false;
            }
            return _vehiclesManager.UpdateVehicleStatus(vehicleStatus.vehicleId, (VehicleStatusEnum)vehicleStatus.status);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}