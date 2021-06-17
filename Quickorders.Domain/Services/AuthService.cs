using AutoMapper;
using Microsoft.Extensions.Configuration;
using Quickorders.Domain.DTOS;
using Quickorders.Domain.Entities;
using Quickorders.Domain.IRepository;
using Quickorders.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _conf;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration conf)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._conf = conf;
        }

        public async Task<ClientResponse<UserProfileDto>> Signin(UserForLoginDto userForLogin)
        {
            var response = new ClientResponse<UserProfileDto>();

            User user = await _unitOfWork.Users.GetByUserName(userForLogin.UserName);

            if (user == null)
            {
                response.Message = "Username is invalid";
                return response;
            }
                 

            var result = await _unitOfWork.Auth.VerifyUser(user, userForLogin.Password);

            if (!result.Succeeded)
            {
                response.Message = "Password is invalid";
                return response;
            }

            var encryp = new EncryptService(_conf);
            string token = encryp.GenerateUserToken(user);

            UserProfileDto profile = _mapper.Map<UserProfileDto>(user);
            profile.FullName = $"{profile.Name} {profile.LastName}";

            

            if (user.IsOwner)
            {
                var restaurants = await _unitOfWork.Restaurants.GetByOwnerId(user.NumberId);
                foreach(var restaurant in restaurants)
                {
                    profile.Restaurants.Add(_mapper.Map<RestaurantProfileDto>(restaurant));
                }
            }

            response.Data = profile;
            response.Token = token;

            return response;
        }
    }
}
