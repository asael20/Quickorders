using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.DTOS
{
    public class UserForCreateDto
    {
        public string NumberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsOwner { get; set; }
        public RestaurantForCreateDto Restaurant { get; set; }
    }
}
