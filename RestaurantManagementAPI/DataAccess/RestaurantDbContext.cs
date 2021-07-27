using Microsoft.EntityFrameworkCore;
using RestaurantManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementAPI.DataAccess
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

       
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
