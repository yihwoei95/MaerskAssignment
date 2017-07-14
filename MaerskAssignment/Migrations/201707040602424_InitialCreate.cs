namespace MaerskAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        DepartureShipyardID = c.Int(nullable: false),
                        ArrivalShipyardID = c.Int(nullable: false),
                        ArrivalShipyard_ShipyardID = c.Int(),
                        DepartureShipyard_ShipyardID = c.Int(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Shipyards", t => t.ArrivalShipyard_ShipyardID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .ForeignKey("dbo.Shipyards", t => t.DepartureShipyard_ShipyardID)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: false)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID)
                .Index(t => t.ArrivalShipyard_ShipyardID)
                .Index(t => t.DepartureShipyard_ShipyardID);
            
            CreateTable(
                "dbo.Shipyards",
                c => new
                    {
                        ShipyardID = c.Int(nullable: false, identity: true),
                        ShipyardName = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ShipyardID);
            
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerDescription = c.String(nullable: false),
                        ContainerWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipType = c.String(),
                        TotalContainers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Bookings", "DepartureShipyard_ShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Bookings", "ContainerID", "dbo.Containers");
            DropForeignKey("dbo.Bookings", "ArrivalShipyard_ShipyardID", "dbo.Shipyards");
            DropIndex("dbo.Bookings", new[] { "DepartureShipyard_ShipyardID" });
            DropIndex("dbo.Bookings", new[] { "ArrivalShipyard_ShipyardID" });
            DropIndex("dbo.Bookings", new[] { "ContainerID" });
            DropIndex("dbo.Bookings", new[] { "ShipID" });
            DropTable("dbo.Ships");
            DropTable("dbo.Containers");
            DropTable("dbo.Shipyards");
            DropTable("dbo.Bookings");
        }
    }
}
