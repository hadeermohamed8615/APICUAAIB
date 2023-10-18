using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;
using APICUAAIB.Models;

namespace APICUAAIB.Entities
{
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AAIBCU;Trusted_Connection=True;Encrypt=False");
          //  Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
