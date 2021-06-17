using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    public class Owner
    {
        [Key]
        public string Id { get; set; }
        public int Status { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
