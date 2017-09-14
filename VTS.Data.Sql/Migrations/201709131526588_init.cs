namespace VTS.Data.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 150),
                        CustomerAddress = c.String(maxLength: 500),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RegistrationNo = c.String(maxLength: 10),
                        VIN = c.String(maxLength: 50),
                        CustomerId = c.Long(nullable: false),
                        VehicleStatus = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleStatus", t => t.VehicleStatus)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.VehicleStatus);
            
            CreateTable(
                "dbo.VehicleStatus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StatusName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Vehicle", "VehicleStatus", "dbo.VehicleStatus");
            DropIndex("dbo.Vehicle", new[] { "VehicleStatus" });
            DropIndex("dbo.Vehicle", new[] { "CustomerId" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.VehicleStatus");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Customer");
        }
    }
}
