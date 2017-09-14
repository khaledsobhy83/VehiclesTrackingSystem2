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
    public class VehicleControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            IEnumerable<VehicleDTO> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Count());
            Assert.AreEqual("YS2R4X20005399401", result.ElementAt(0).VehicleId);
            
        }

        [TestMethod]
        public void GetByCustomer_Success()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            IEnumerable<VehicleDTO> result = controller.GetByCustomer(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("YS2R4X20005399401", result.ElementAt(0).VehicleId);

        }

        [TestMethod]
        public void GetByCustomer_NoResult()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            IEnumerable<VehicleDTO> result = controller.GetByCustomer(5);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());

        }
        [TestMethod]
        public void GetByStatus_Online_Success()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            IEnumerable<VehicleDTO> result = controller.GetByStatus(1);

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(0, result.Count());
            
        }
        [TestMethod]
        public void GetByStatus_Offline_Success()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            IEnumerable<VehicleDTO> result = controller.GetByStatus(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Count());
            Assert.AreEqual("YS2R4X20005387055", result.LastOrDefault().VehicleId);
        }
        [TestMethod]
        public void GetByStatus_InvalidStatus()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            IEnumerable<VehicleDTO> result = controller.GetByStatus(10);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void UpdateVehicleStatus_Success()
        {
            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            var result = controller.UpdateMyStatus(new VehicleStatusStruct() { vehicleId = "YS2R4X20005399401", status = 1 });

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(6, controller.GetByStatus(2).Count());
            Assert.AreEqual(1, controller.GetByStatus(1).Count());
        }
        [TestMethod]
        public void UpdateVehicleStatus_InvalidStatus()
        {
            //I kept this specific test that will fail to show that I missed to handle wrong status being sent
            //this is the real value of unit tests

            // Arrange
            VehicleController controller = new VehicleController(vehiclesManager);

            // Act
            var result = controller.UpdateMyStatus(new VehicleStatusStruct() { vehicleId = "YS2R4X20005399401", status = 5 });

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
