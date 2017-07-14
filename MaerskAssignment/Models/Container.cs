using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskAssignment.Models
{
    public class Container
    {
        public int ContainerID { get; set; }

        [Required]
        public String ContainerDescription { get; set; }

        public int ContainerWeight { get; set; }
    }
}