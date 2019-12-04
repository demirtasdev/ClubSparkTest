using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubSparkTest.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool Eliminated { get; set; }
    }
}