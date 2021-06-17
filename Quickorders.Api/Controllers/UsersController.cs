using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quickorders.Domain.IServices;
using Quickorders.Domain.DTOS;
using AutoMapper;
using Quickorders.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Quickorders.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
          
        }


        [HttpPost]
        public async Task<ActionResult> Register( UserForCreateDto userToCreate)
        {
            var result = await _userService.CreateUser(userToCreate);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }



    }
}
