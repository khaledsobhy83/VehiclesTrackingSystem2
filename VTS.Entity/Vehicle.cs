namespace VTS.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        public long Id { get; set; }

        [StringLength(10)]
        public string RegistrationNo { get; set; }

        [StringLength(50)]
        public string VIN { get; set; }

        public long CustomerId { get; set; }

        public int VehicleStatus { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual VehicleStatus VehicleStatus1 { get; set; }
    }
}
