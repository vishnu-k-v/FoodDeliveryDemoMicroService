using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementAPI.DataAccess;
using RestaurantManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementAPI.Infra
{
    public static class PrapareDb
    {
        public static void PrePopulation(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                try
                {
                    SeedData(scope.ServiceProvider.GetService<RestaurantDbContext>());

                }
                catch (Exception bex)
                {

                    throw;
                }
            }
        }


        private static void SeedData(RestaurantDbContext context)
        {
            context.Database.Migrate();
            if (!context.Restaurant.Any())
            {
                context.Restaurant.Add(new Restaurant
                {
                    Name = "Sample Rest"
                });
                context.SaveChanges();
            }
            if (!context.Item.Any())
            {
                var restId = context.Restaurant.FirstOrDefault().Id;
                context.Item.AddRange(new Item { Name = "Item1", RestaurantId = restId },
                    new Item { Name = "Item2", RestaurantId = restId });
                context.SaveChanges();
            }

        }
    }
}
