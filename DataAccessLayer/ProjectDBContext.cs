using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntities;

namespace DataAccessLayer
{
    public class ProjectDBContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;initial catalog=ProjectDB;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
