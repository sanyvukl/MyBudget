using Microsoft.EntityFrameworkCore;
using MyBudget.Models;
using MyBudget.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                new Category { Id = 1, Name = "Food", Icon = "-", Type = SD.Category_Expense},
                new Category { Id = 2, Name = "Travelling", Icon = "-", Type = SD.Category_Expense},
                new Category { Id = 3, Name = "Work", Icon = "+", Type = SD.Category_Income}
            });

            modelBuilder.Entity<Transaction>().HasData(new List<Transaction>()
            {
                new Transaction { Id = 1,  Title = "Flight to Turkey", Description = "I bought a ticket to Antalya", Amount = 500, DateTime = DateTime.Now, CategoryId = 2},
                new Transaction { Id = 2,  Title = "Got Salary", Description = "I got a salary ", Amount = 2000, DateTime = DateTime.Now, CategoryId = 3},
                new Transaction { Id = 3,  Title = "Costco", Description = "I bought food in costco ", Amount = 300, DateTime = DateTime.Now, CategoryId = 1}
            });
        }
    }
}
