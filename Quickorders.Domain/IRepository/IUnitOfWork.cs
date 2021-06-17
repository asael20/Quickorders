using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.IRepository
{
    public interface IUnitOfWork
    {
        IOwnerRepository Owners { get; }
        IRestaurantRepository Restaurants { get; }
        IUserRepository Users { get; }
        IAuthRepository Auth { get; }
       
        

    }
}
