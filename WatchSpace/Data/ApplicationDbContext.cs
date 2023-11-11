using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using WatchSpace.Models;

namespace WatchSpace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
    }
}
