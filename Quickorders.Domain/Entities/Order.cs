﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }      
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
