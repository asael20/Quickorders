using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Entities
{
    public class ClientResponse<TData>
    {
        public int Status { get; set; }
        public TData Data { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string Token { get; set; }
        

    }
}
