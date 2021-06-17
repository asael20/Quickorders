using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    [Index(nameof(Name), nameof(MenuId), IsUnique =true)]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Order> Orders { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
