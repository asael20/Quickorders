using Microsoft.AspNetCore.Identity;
using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.IRepository
{
    public interface IAuthRepository
    {
        Task<SignInResult> VerifyUser(User user, string password);
    }
}
