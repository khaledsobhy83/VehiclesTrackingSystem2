using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace VTS.Test
{
    [TestClass]
    public class CustomerManagerTest : TestBase
    {
        
        [TestMethod]
        public void GetAllVehicles_Success()
        {
            var customerList = customerManager.GetAllCutomers();

            Assert.AreEqual(customerList.Count, 3);
        }
    }
}
