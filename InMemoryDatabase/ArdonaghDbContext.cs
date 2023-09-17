using ArdonaghTestWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ArdonaghTestWebApp.InMemoryDatabase
{

    public class ArdonaghDbContext : DbContext
    {
        public ArdonaghDbContext(DbContextOptions<ArdonaghDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }

}
