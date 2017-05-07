using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace VTS.Test
{
    [TestClass]
    public class VehicleManagerTest : TestBase
    {
        
        [TestMethod]
        public void GetAllVehicles_Success()
        {
            var vehiclesList = vehiclesManager.GetAllVehicles();

            Assert.AreEqual(vehiclesList.Count, 1);

            Assert.AreEqual(vehiclesList[0].Vehicles.Count, 3);
        }

        [TestMethod]
        public void GetVehiclesByCustomer_Success()
        {
            var vehiclesList = vehiclesManager.GetVehiclesByCustomer(1);

            Assert.AreEqual(vehiclesList.Count, 1);

            Assert.AreEqual(vehiclesList[0].Vehicles.Count, 3);
        }
        [TestMethod]
        public void GetVehiclesByCustomer_NoResults()
        {
            var vehiclesList = vehiclesManager.GetVehiclesByCustomer(5);

            Assert.AreEqual(vehiclesList.Count, 0);
        }

        [TestMethod]
        public void GetVehiclesByStatus_Success()
        {
            var vehiclesList = vehiclesManager.GetVehiclesByStatus(Helpers.Enums.VehicleStatusEnum.Offline);

            Assert.AreEqual(vehiclesList.Count, 1);

            Assert.AreEqual(vehiclesList[0].Vehicles.Count, 3);
        }
        [TestMethod]
        public void GetVehiclesByStatus_NoResults()
        {
            var vehiclesList = vehiclesManager.GetVehiclesByStatus(Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(vehiclesList.Count, 0);
        }

        [TestMethod]
        public void UpdateVehicleStatus_Success()
        {
           var result = vehiclesManager.UpdateVehicleStatus("VLUR4X20009093588", Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(result, true);

            var vehiclesList = vehiclesManager.GetVehiclesByStatus(Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(vehiclesList.Count, 1);

            Assert.AreEqual(vehiclesList[0].Vehicles[0].VehicleId, "VLUR4X20009093588");
        }
        [TestMethod]
        public void UpdateVehicleStatus_InvalidVehicle()
        {
            var result = vehiclesManager.UpdateVehicleStatus("xxxx0000", Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(result, false);

            var vehiclesList = vehiclesManager.GetVehiclesByStatus(Helpers.Enums.VehicleStatusEnum.Online);

            Assert.AreEqual(vehiclesList.Count, 0);

        }
    }
}
