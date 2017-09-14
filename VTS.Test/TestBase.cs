    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using VTS.DependencyInjectionRegister;
using VTS.BL;
using System.Data.Entity;
using VTS.Data.Sql;
using Effort;
using System.Data.Entity.Core.Objects;
using VTS.Repository;

namespace VTS.Test
{
    public class TestBase
    {
        protected IVehiclesManager vehiclesManager;
        protected ICustomerManager customerManager;

        VTSModel _context;
        public TestBase()
        {
            _context = new VTSModel(DbConnectionFactory.CreateTransient());

            InitializeDB();

            //Dependency injection configuration
            var builder = new ContainerBuilder();
            
            builder.Register<IVehicleRepository>(c => new VehicleRepository(_context)).InstancePerLifetimeScope();

            builder.Register<ICustomerRepository>(c => new CustomerRepository(_context)).InstancePerLifetimeScope();
            
            builder = ServiceRegistry.RegisterForTest(builder);

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                vehiclesManager = scope.Resolve<IVehiclesManager>();
                customerManager = scope.Resolve<ICustomerManager>();
            }
        }
        private void InitializeDB()
        {
            _context.VehicleStatus.Add(new Entity.VehicleStatus()
            {
                Id = 1,
                StatusName = "Online"
            });
            _context.VehicleStatus.Add(new Entity.VehicleStatus()
            {
                Id = 2,
                StatusName = "Offline"
            });
            _context.VehicleStatus.Add(new Entity.VehicleStatus()
            {
                Id = 3,
                StatusName = "Unknown"
            });
            _context.Customer.Add(new Entity.Customer()
            {
                Id= 1,
                CustomerName = "Kalles Grustransporter AB",
                CustomerAddress = "Cementvägen 8, 111 11 Södertälje",
                IsDeleted = false,
                IsActive = true,
            });
            _context.Customer.Add(new Entity.Customer()
            {
                Id = 2,
                CustomerName = "Johans Bulk AB",
                CustomerAddress = "Balkvägen 12, 222 22 Stockholm",
                IsDeleted = false,
                IsActive = true
            });
            _context.Customer.Add(new Entity.Customer()
            {
                Id=3,
                CustomerName = "Haralds Värdetransporter AB",
                CustomerAddress = "Budgetvägen 1, 333 33 Uppsala",
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id=1,
                RegistrationNo= "ABC123",
                VIN= "YS2R4X20005399401",
                CustomerId=1,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id = 2,
                RegistrationNo = "DEF456",
                VIN = "VLUR4X20009093588",
                CustomerId = 1,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id = 3,
                RegistrationNo = "GHI789",
                VIN = "VLUR4X20009048066",
                CustomerId = 1,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id = 4,
                RegistrationNo = "JKL012",
                VIN = "YS2R4X20005388011",
                CustomerId = 2,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id = 5,
                RegistrationNo = "MNO345",
                VIN = "YS2R4X20005387949",
                CustomerId = 2,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id = 6,
                RegistrationNo = "PQR678",
                VIN = "YS2R4X20005387765",
                CustomerId = 3,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            _context.Vehicle.Add(new Entity.Vehicle()
            {
                Id = 7,
                RegistrationNo = "STU901",
                VIN = "YS2R4X20005387055",
                CustomerId = 3,
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });

            _context.SaveChanges();
        }
    }
    
}
