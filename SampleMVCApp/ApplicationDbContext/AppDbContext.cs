using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Npgsql;
namespace SampleMVCApp.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base(nameOrConnectionString: "PostGreConnection")
        {

        }
        public DbSet<Models.Employee> Employees { get; set; }
    }
}