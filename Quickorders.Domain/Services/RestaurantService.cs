using AutoMapper;
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
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RestaurantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ClientResponse<dynamic>> AddMenu(MenuForCreateDto menuForCreate)
        {

            ClientResponse<dynamic> response = new ClientResponse<dynamic>();


            var restaurant = await _unitOfWork.Restaurants.GetByNit(menuForCreate.RestaurantNit);

            if(restaurant == null)
            {
                response.Message = "Restaurant Not exist";
                return response;
            }

            var menu = _mapper.Map<Menu>(menuForCreate);
            var repoResult = await _unitOfWork.Restaurants.AddMenu(menu);

            

            if (!repoResult.Success)
            {
                response.Message = "Bad request for add a menu";
                return response;
            }

            response.Message = "Menu added successfully";
            response.Success = true;

            return response;
        }
    }
}
