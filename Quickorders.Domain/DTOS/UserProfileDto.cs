using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.DTOS
{
    public class UserProfileDto
    {
        public UserProfileDto()
        {
            Restaurants = new List<RestaurantProfileDto> { };
        }

        public string FullName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NumberId { get; set; }
        public bool IsOwner { get; set; }
        public List<RestaurantProfileDto> Restaurants { get; set; }
        
    }
}
