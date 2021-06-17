using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.DTOS
{
    public class UserCreatedDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }

}