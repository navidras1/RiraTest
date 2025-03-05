using DataAccess.RiraModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
     public class RiraContext : DbContext
    {
        public RiraContext() { }
        protected RiraContext(DbContextOptions<RiraContext> options):base(options) 
        {
        }
        public virtual DbSet<Person> Persons { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RiraTestDatabse.db");
        }
    }
}
