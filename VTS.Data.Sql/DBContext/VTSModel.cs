namespace VTS.Data.Sql
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using VTS.Entity;
    using System.Data.Common;
    using Migrations;
    public partial class VTSModel : DbContext
    {
        public VTSModel()
            : base("name=VTSModel2")
        {

            Database.SetInitializer(new DBInitializer());
        }
        public VTSModel(DbConnection conn)
           : base(conn,true)
        {
            
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleStatus> VehicleStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Vehicle)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleStatus>()
                .HasMany(e => e.Vehicle)
                .WithRequired(e => e.VehicleStatus1)
                .HasForeignKey(e => e.VehicleStatus)
                .WillCascadeOnDelete(false);
        }
    }
}
