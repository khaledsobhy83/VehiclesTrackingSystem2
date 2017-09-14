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
    public class CustomerController : ApiController
    {
        private ICustomerManager _manager;

        public CustomerController(ICustomerManager customerManager)
        {
            _manager = customerManager;
        }

        // GET api/<controller>
        public IEnumerable<CustomerDTO> Get()
        {
            return _manager.GetAllCutomers().GetDTO();
        }

       
    }
}