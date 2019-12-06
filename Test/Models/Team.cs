namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;
    using Test.ViewModels;
    using ExtensionMethods;

    [Table("Team")]
    public partial class Team
    {
        [Key]
        [Column(Order = 1)]
        public double ID { get; set; }

        [StringLength(255)]
        [Column(Order = 2)]
        public string Name { get; set; }

        [StringLength(255)]
        [Column(Order = 3)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Eliminated { get; set; }
    }
}
