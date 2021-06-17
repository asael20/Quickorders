using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.DTOS
{
    public class MenuForCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RestaurantNit { get; set; }
    }
}
