using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementAPI.Models
{
  
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
