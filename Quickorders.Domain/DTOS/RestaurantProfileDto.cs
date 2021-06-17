using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.DTOS
{
    public class RestaurantProfileDto
    {
        public int Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberMenus { get; set; }
    }
}
