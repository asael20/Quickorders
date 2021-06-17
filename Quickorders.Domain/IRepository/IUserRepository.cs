using Microsoft.AspNetCore.Identity;
using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<IdentityResult> Insert(User user, string password);
        Task<User> GetByUserName(string userName);
    }
}
