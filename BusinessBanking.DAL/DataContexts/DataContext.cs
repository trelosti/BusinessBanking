using BusinessBanking.DAL.Util;
using BusinessBanking.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
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

            var currencyList = CsvReader.ReadCurrencies();
            List<Currency> currencies = new List<Currency>();
            var currencyIdCounter = 1;

            foreach (var currency in currencyList)
            {
                currencies.Add(new Currency
                {
                    ID = currencyIdCounter++,
                    CurrencyID = currency[0],
                    CurrencySymbol = currency[1],
                    CurrencyName = currency[2]
                });
            }

            modelBuilder.Entity<Currency>().HasData(currencies);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(c => c.User)
                .WithMany(u => u.CustomerAccounts)
                .HasForeignKey(c => c.CustomerID)
                .HasPrincipalKey(u => u.CustomerID);


            modelBuilder.Entity<CustomerAccount>()
                .HasOne(c => c.Currency)
                .WithMany(cr => cr.CustomerAccounts)
                .HasForeignKey(c => c.CurrencyID)
                .HasPrincipalKey(cr => cr.CurrencyID);

            modelBuilder.Entity<CustomerAccount>().HasData(new CustomerAccount[] {
                new CustomerAccount
                {
                    ID = 1,
                    CustomerID = 1,
                    AccountType = 0,
                    AccountNo = "1240020000000001",
                    CurrencyID = "840",
                    AccountName = "Банковские счета юридических лиц",
                    AvailableBalance = 137.53M,
                    OpenDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    CloseDate = null
                },
                new CustomerAccount
                {
                    ID = 2,
                    CustomerID = 1,
                    AccountType = 0,
                    AccountNo = "1240020000000002",
                    CurrencyID = "417",
                    AccountName = "Банковские счета ИП ",
                    AvailableBalance = 49315.07M,
                    OpenDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    CloseDate = null
                },
                new CustomerAccount
                {
                    ID = 3,
                    CustomerID = 1,
                    AccountType = 1,
                    AccountNo = "1243010000000001",
                    CurrencyID = "417",
                    AccountName = "Классический 365/факт",
                    AvailableBalance = 1000000M,
                    OpenDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1),
                    CloseDate = null
                },
             });
        }

        public DbSet<User> Users { get; set; }

        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; } 
    }
}
