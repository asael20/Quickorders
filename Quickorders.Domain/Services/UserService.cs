using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<ClientResponse<UserCreatedDto>> CreateUser(UserForCreateDto userForCreateDto)
        {
            User user = _mapper.Map<User>(userForCreateDto);
            user.UserName = user.Email;

            var result = await _unitOfWork.Users.Insert(user, userForCreateDto.Password);

            if (!result.Succeeded)
            {
                return new ClientResponse<UserCreatedDto> { Data = null, Message = result.Errors.FirstOrDefault().Description , Status = 400, Success = false };
            }

            string message;
            var cryp = new EncryptService(_configuration);           
            var created = new UserCreatedDto { Email = user.Email, Name = user.Name, Token = cryp.GenerateUserToken(user)};
            

            if (user.IsOwner)
            {
                Restaurant restaurant = _mapper.Map<Restaurant>(userForCreateDto.Restaurant);
                restaurant.OwnerId = user.NumberId;

                Owner owner = new Owner { Id = user.NumberId, Status = 1 };
                await _unitOfWork.Owners.Insert(owner);

                var repoResult = await _unitOfWork.Restaurants.Insert(restaurant);
               
                if (!repoResult.Success)
                {
                    message = "User created but his restaurant could not be created";
                    return new ClientResponse<UserCreatedDto> { Data = created, Message = message, Status = 201, Success = true };
                }

                message = "User created succesfully with his Restaurant";
            }


            message = "User created succesfully (basic)";
           
            return new ClientResponse<UserCreatedDto> { Data = created, Message = message, Status = 201, Success = true };
        }






    }
}
