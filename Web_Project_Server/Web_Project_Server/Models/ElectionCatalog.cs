using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Project_Server.Models
{
    public class ElectionCatalog : DbContext
    {
        
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
		public DbSet<Vote> Votes { get; set; }
		public DbSet<Election> Elections { get; set; }
        public DbSet<CandidateApplication> CandidateApplications { get; set; }




    }
}