using ArdonaghTestWebApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ArdonaghTestWebApp.InMemoryDatabase
{
    public static class DatabaseInitialiser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ArdonaghDbContext>();

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                   new Customer { Id = 1, Age = 28, Height = 2, Name = "Waqaas", PostCode = "bs166ua" },
                   new Customer { Id = 2, Age = 25, Height = 2, Name = "Paul", PostCode = "bs166ua" }
                );

                context.SaveChanges();
            }
        }
    }
}
