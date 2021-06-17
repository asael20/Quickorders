using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quickorders.Domain.Entities;
using Quickorders.Domain.IRepository;
using Quickorders.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Infrastructure.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(DataContext context, UserManager<User> userManager)
        {
            _context = context;
           _userManager = userManager;
        }

        public async Task<User> GetByUserName(string userName)
        {
           return  await _context.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> Insert(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
    }
}
