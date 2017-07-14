using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaerskAssignment.Models
{
    public class MaerskAssignmentContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MaerskAssignmentContext() : base("name=MaerskAssignmentContext")
        {
        }

        public System.Data.Entity.DbSet<MaerskAssignment.Models.Container> Containers { get; set; }

        public System.Data.Entity.DbSet<MaerskAssignment.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<MaerskAssignment.Models.Shipyard> Shipyards { get; set; }

        public System.Data.Entity.DbSet<MaerskAssignment.Models.Booking> Bookings { get; set; }
    }
}
