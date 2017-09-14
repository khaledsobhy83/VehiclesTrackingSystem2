namespace VTS.Data.Sql.Migrations
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VTSModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VTSModel context)
        {

            InitializeVehicleStatus(context);

            InitializeCustomer1(context);

            InitializeCustomer2(context);

            InitializeCustomer3(context);

            context.SaveChanges();
        }

        private void InitializeCustomer3(VTSModel context)
        {
            var vehiclesList = new List<Vehicle>();

            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "PQR678",
                VIN = "YS2R4X20005387765",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "STU901",
                VIN = "YS2R4X20005387055",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });


            context.Customer.Add(new Entity.Customer()
            {
                CustomerName = "Haralds Värdetransporter AB",
                CustomerAddress = "Budgetvägen 1, 333 33 Uppsala",
                IsDeleted = false,
                IsActive = true,
                Vehicle = vehiclesList
            });

        }

        private void InitializeCustomer2(VTSModel context)
        {
            var vehiclesList = new List<Vehicle>();

            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "JKL012",
                VIN = "YS2R4X20005388011",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "MNO345",
                VIN = "YS2R4X20005387949",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            context.Customer.Add(new Entity.Customer()
            {
                CustomerName = "Johans Bulk AB",
                CustomerAddress = "Balkvägen 12, 222 22 Stockholm",
                IsDeleted = false,
                IsActive = true,
                Vehicle = vehiclesList
            });
        }

        private void InitializeCustomer1(VTSModel context)
        {
            var vehiclesList = new List<Vehicle>();

            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "ABC123",
                VIN = "YS2R4X20005399401",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "DEF456",
                VIN = "VLUR4X20009093588",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            vehiclesList.Add(new Entity.Vehicle()
            {
                RegistrationNo = "GHI789",
                VIN = "VLUR4X20009048066",
                VehicleStatus = 2,
                IsDeleted = false,
                IsActive = true
            });
            context.Customer.Add(new Entity.Customer()
            {
                CustomerName = "Kalles Grustransporter AB",
                CustomerAddress = "Cementvägen 8, 111 11 Södertälje",
                IsDeleted = false,
                IsActive = true,
                Vehicle = vehiclesList
            });
        }

        private void InitializeVehicleStatus(VTSModel context)
        {
            context.VehicleStatus.Add(new Entity.VehicleStatus()
            {
                Id = 1,
                StatusName = "Online"
            });
            context.VehicleStatus.Add(new Entity.VehicleStatus()
            {
                Id = 2,
                StatusName = "Offline"
            });
            context.VehicleStatus.Add(new Entity.VehicleStatus()
            {
                Id = 3,
                StatusName = "Unknown"
            });
        }
    }
}
