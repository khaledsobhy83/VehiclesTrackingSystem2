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
            if (File.Exists(GetStoreFilePath()))
            {
                DeserializeCollection();
            }
            else
            {

                CustomerStore customer = new CustomerStore();
                customer.CustomerName = "Kalles Grustransporter AB";
                customer.CustomerAddress = "Cementvägen 8, 111 11 Södertälje";
                customer.ID = 1;
                customer.Vehicles = new List<VehicleStore>();
                customer.Vehicles.Add(new VehicleStore()
                {
                    CustomerId = customer.ID,
                    RegistrationNo = "ABC123",
                    VehicleId = "YS2R4X20005399401",
                    VehicleStatus = "Offline"
                });
                customer.Vehicles.Add(new VehicleStore()
                {
                    CustomerId = customer.ID,
                    RegistrationNo = "DEF456",
                    VehicleId = "VLUR4X20009093588",
                    VehicleStatus = "Online"
                });

                customer.Vehicles.Add(new VehicleStore()
                {
                    CustomerId = customer.ID,
                    RegistrationNo = "GHI789",
                    VehicleId = "VLUR4X20009048066",
                    VehicleStatus = "Offline"
                });

                customersVehicles.Add(customer);



            //    CustomerStore customer2 = new CustomerStore();
            //    customer2.CustomerName = "Johans Bulk AB";
            //    customer2.CustomerAddress = "Balkvägen 12, 222 22 Stockholm";
            //    customer2.ID = 2;
            //    customer2.Vehicles = new List<VehicleStore>();
            //    customer2.Vehicles.Add(new VehicleStore()
            //    {
            //        CustomerId = customer2.ID,
            //        RegistrationNo = "JKL012",
            //        VehicleId = "YS2R4X20005388011",
            //        VehicleStatus = "Offline"
            //    });
            //    customer2.Vehicles.Add(new VehicleStore()
            //    {
            //        CustomerId = customer2.ID,
            //        RegistrationNo = "MNO345",
            //        VehicleId = "YS2R4X20005387949",
            //        VehicleStatus = "Offline"
            //    });
                
            //    customersVehicles.Add(customer2);

            //    CustomerStore customer3 = new CustomerStore();
            //    customer3.CustomerName = "Haralds Värdetransporter AB";
            //    customer3.CustomerAddress = "Budgetvägen 1, 333 33 Uppsala";
            //    customer3.ID = 3;
            //    customer3.Vehicles = new List<VehicleStore>();
            //    customer3.Vehicles.Add(new VehicleStore()
            //    {
            //        CustomerId = customer3.ID,
            //        RegistrationNo = "PQR678",
            //        VehicleId = "YS2R4X20005387765",
            //        VehicleStatus = "Offline"
            //    });
            //    customer3.Vehicles.Add(new VehicleStore()
            //    {
            //        CustomerId = customer3.ID,
            //        RegistrationNo = "STU901",
            //        VehicleId = "YS2R4X20005387055",
            //        VehicleStatus = "Offline"
            //    });


            //    customersVehicles.Add(customer3);
            }
            SerializeCollection();
        }
        public static void SerializeCollection()
        {
            var jsonSerialiser = new JavaScriptSerializer();

            var json = jsonSerialiser.Serialize(CustomersVehicles);

            File.WriteAllText(GetStoreFilePath(), json);
        }

        public static void DeserializeCollection()
        {
            var jsonSerialiser = new JavaScriptSerializer();

            var json = File.ReadAllText(GetStoreFilePath());

            customersVehicles = jsonSerialiser.Deserialize<List<CustomerStore>>(json);
        }

        private static string GetStoreFilePath()
        {
            var directoryPath = Path.GetDirectoryName((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);

            var path = string.Format("{0}\\CollectionStore.json", directoryPath);

            return path;
        }
    }
}
