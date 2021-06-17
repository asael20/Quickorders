using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    [Index(nameof(Title), nameof(RestaurantNit), IsUnique=true)]
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RestaurantNit { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Product> Products { get; set; }

    }
}
