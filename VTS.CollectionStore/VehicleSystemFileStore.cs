using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace VTS.FileStore
{
    /// <summary>
    /// This class acts as data store like database but it saves data in memory and serialize it to file, 
    /// You can say file store
    /// </summary>
    public class VehicleSystemFileStore
    {
        private static List<CustomerStore> customersVehicles;
        public static List<CustomerStore> CustomersVehicles
        {
            get
            {
                if (customersVehicles == null)
                {
                    customersVehicles = new List<CustomerStore>();

                    InitializeCollection();

                    return customersVehicles;
                }
                else
                {
                    return customersVehicles;
                }
            }
            set
            {
                customersVehicles = value;
            }
        }

        public static void InitializeCollection()
        {
            CustomerStore customer = new CustomerStore();
            customer.CustomerName = "Kalles Grustransporter AB";
            customer.CustomerAddress = "Cementvägen 8, 111 11 Södertälje";
            customer.ID = 1;
            customer.Vehicles = new List<VehicleStore>();
            customer.Vehicles.Add(new VehicleStore()
            {
                CustomerId= customer.ID,
                RegistrationNo = "ABC123",
                VehicleId = "YS2R4X20005399401",
                VehicleStatus = "Offline"
            });
            customer.Vehicles.Add(new VehicleStore()
            {
                CustomerId = customer.ID,
                RegistrationNo = "DEF456",
                VehicleId = "VLUR4X20009093588",
                VehicleStatus = "Offline"
            });

            customer.Vehicles.Add(new VehicleStore()
            {
                CustomerId = customer.ID,
                RegistrationNo = "GHI789",
                VehicleId = "VLUR4X20009048066",
                VehicleStatus = "Offline"
            });

            customersVehicles.Add(customer);
        }
        public static void SerializeCollection()
        {
            var jsonSerialiser = new JavaScriptSerializer();

            var json = jsonSerialiser.Serialize(CustomersVehicles);

            var directoryPath = Path.GetDirectoryName((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);

            File.WriteAllText(string.Format("{0}\\CollectionStore.json", directoryPath), json);
        }

        public static void DeserializeCollection()
        {
            var jsonSerialiser = new JavaScriptSerializer();

            var directoryPath = Path.GetDirectoryName((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);

            var json = File.ReadAllText(string.Format("{0}\\CollectionStore.json", directoryPath));

            customersVehicles = jsonSerialiser.Deserialize<List<CustomerStore>>(json);
        }
    }
}
