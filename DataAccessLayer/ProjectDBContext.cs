using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccessLayer
{

    public class ProjectDBContext : IdentityDbContext<User>
    {
        public ProjectDBContext()
        {

        }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> dbContext):base(dbContext)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TUMHS1A\MS_SQL_2019;initial catalog=ProjectDB;integrated security=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
