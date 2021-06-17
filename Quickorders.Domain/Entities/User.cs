using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    [Index(nameof(NumberId), IsUnique =true)]
    public class User: IdentityUser
    {
        public string NumberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsOwner { get; set; }
       
        public List<Order> Orders { get; set; }
    }
}
