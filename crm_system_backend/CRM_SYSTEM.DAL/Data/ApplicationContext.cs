using CRM_SYSTEM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Status> UserStatus => Set<Status>();
        public DbSet<Rating> Ratings => Set<Rating>();
        public DbSet<Passes> Passes => Set<Passes>();
        public DbSet<Debts> Debts => Set<Debts>();
        public DbSet<Lessons> Lessons => Set<Lessons>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=crm_system;password=;Pooling=true");
            }
        }
    }
}
