using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Restaurant
    {
        [Key]
        public int Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
