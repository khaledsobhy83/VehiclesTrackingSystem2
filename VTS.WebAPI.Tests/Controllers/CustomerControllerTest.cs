using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VTS.WebAPI;
using VTS.WebAPI.Controllers;
using VTS.DTO;
using Autofac;
using VTS.DependencyInjectionRegister;
using VTS.BL;
using VTS.Helpers;

namespace VTS.WebAPI.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void Get_Success()
        {
            // Arrange
            CustomerController controller = new CustomerController(customerManager);

            // Act
            IEnumerable<CustomerDTO> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Kalles Grustransporter AB", result.ElementAt(0).CustomerName);
            
        }
        
    }
}
