namespace MaerskAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBooking : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "ArrivalShipyard_ShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Bookings", "DepartureShipyard_ShipyardID", "dbo.Shipyards");
            DropIndex("dbo.Bookings", new[] { "ArrivalShipyard_ShipyardID" });
            DropIndex("dbo.Bookings", new[] { "DepartureShipyard_ShipyardID" });
            DropColumn("dbo.Bookings", "DepartureShipyardID");
            DropColumn("dbo.Bookings", "ArrivalShipyardID");
            RenameColumn(table: "dbo.Bookings", name: "ArrivalShipyard_ShipyardID", newName: "DepartureShipyardID");
            RenameColumn(table: "dbo.Bookings", name: "DepartureShipyard_ShipyardID", newName: "ArrivalShipyardID");
            AlterColumn("dbo.Bookings", "DepartureShipyardID", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "ArrivalShipyardID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "DepartureShipyardID");
            CreateIndex("dbo.Bookings", "ArrivalShipyardID");
            AddForeignKey("dbo.Bookings", "DepartureShipyardID", "dbo.Shipyards", "ShipyardID", cascadeDelete: false);
            AddForeignKey("dbo.Bookings", "ArrivalShipyardID", "dbo.Shipyards", "ShipyardID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "ArrivalShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.Bookings", "DepartureShipyardID", "dbo.Shipyards");
            DropIndex("dbo.Bookings", new[] { "ArrivalShipyardID" });
            DropIndex("dbo.Bookings", new[] { "DepartureShipyardID" });
            AlterColumn("dbo.Bookings", "ArrivalShipyardID", c => c.Int());
            AlterColumn("dbo.Bookings", "DepartureShipyardID", c => c.Int());
            RenameColumn(table: "dbo.Bookings", name: "ArrivalShipyardID", newName: "DepartureShipyard_ShipyardID");
            RenameColumn(table: "dbo.Bookings", name: "DepartureShipyardID", newName: "ArrivalShipyard_ShipyardID");
            AddColumn("dbo.Bookings", "ArrivalShipyardID", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "DepartureShipyardID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "DepartureShipyard_ShipyardID");
            CreateIndex("dbo.Bookings", "ArrivalShipyard_ShipyardID");
            AddForeignKey("dbo.Bookings", "DepartureShipyard_ShipyardID", "dbo.Shipyards", "ShipyardID");
            AddForeignKey("dbo.Bookings", "ArrivalShipyard_ShipyardID", "dbo.Shipyards", "ShipyardID");
        }
    }
}
