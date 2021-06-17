using Microsoft.AspNetCore.Identity;
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
    public class UnitOfWork : IUnitOfWork
    {

        private IUserRepository _userRepository;
        private IRestaurantRepository _restaurantRepository;
        private IOwnerRepository _ownerRepository;
        private IAuthRepository _authRepository;

        public UnitOfWork(DataContext context, UserManager<User> userManager, SignInManager<User> signInManager) 
        {
            _restaurantRepository = new RestaurantRepository(context);
            _ownerRepository = new OwnerRepository(context);
            _userRepository = new UserRepository(context, userManager);
            _authRepository = new AuthRepository(signInManager);
        }

        public IOwnerRepository Owners => _ownerRepository;

        public IRestaurantRepository Restaurants => _restaurantRepository;

        public IUserRepository Users => _userRepository;

        public IAuthRepository Auth => _authRepository;
    }
}
