using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace JobExample.Models
{
    public class JobContext :DbContext 
    {
        public JobContext():base("name=JobsDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}