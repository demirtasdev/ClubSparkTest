using ClubSparkTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClubSparkTest.DAL
{
    public class SportslabsContext : DbContext
    {
        public SportslabsContext() : base("name=SportslabsContext")
        {
        }

        public DbSet<Team> Teams { get; set; }
    }

}