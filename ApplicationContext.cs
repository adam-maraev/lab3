using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IGI_3.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext() : base(new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=temp;Integrated Security=True").Options)
        {
            Database.EnsureCreated();
        }
    }
}
