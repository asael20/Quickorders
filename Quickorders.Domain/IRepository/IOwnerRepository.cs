using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.IRepository
{
    public interface IOwnerRepository
    {
        Task<DatabaseResponse<string>> Insert(Owner owner);
    }
}
