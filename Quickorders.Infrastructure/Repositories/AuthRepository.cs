using Microsoft.AspNetCore.Identity;
using Quickorders.Domain.Entities;
using Quickorders.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Infrastructure.Repositories
{
    class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<User> _signInManager;

        public AuthRepository(SignInManager<User> signInManager)
        {
            this._signInManager = signInManager;
        }

        public async Task<SignInResult> VerifyUser(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }
    }
}
