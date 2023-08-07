using BusinessBanking.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.DAL.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Login);

            modelBuilder.Entity<User>().HasData(new User[] {
                new User
                {
                    ID = 1,
                    CustomerID = 1,
                    Login = "user",
                    Password = "ee11cbb19052e40b07aac0ca060c23ee",
                    UserAccess = 1
                },
            });
        }

        public DbSet<User> Users { get; set; }
    }
}
