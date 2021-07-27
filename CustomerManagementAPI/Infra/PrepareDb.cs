using CustomerManagementAPI.DataAccess;
using CustomerManagementAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Infra
{
    public static class PrepareDb
    {
        public static void PrePopulation(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                try
                {
                    SeedData(scope.ServiceProvider.GetService<CustomerDbContext>());

                }
                catch (Exception bex)
                {

                    throw;
                }
            }
        }


        private static void SeedData(CustomerDbContext context)
        {
            context.Database.Migrate();
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer
                {
                    Name = "Sample Customer Name"
                });
                context.SaveChanges();
            }
           

        }
    }
}
