using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quickorders.Domain.DTOS;
using Quickorders.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quickorders.Api.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController: ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }

        [HttpPost("{id}/Menus")]
        public async Task<ActionResult> AddMenu(int id, MenuForCreateDto menuForCreate)
        {
            menuForCreate.RestaurantNit = id;
            var response = await _restaurantService.AddMenu(menuForCreate);

            return response.Success ? Created("", response) : BadRequest(response);
        }

        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok("All right!!");
        }


    }
}
