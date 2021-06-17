using Microsoft.AspNetCore.Mvc;
using Quickorders.Domain.DTOS;
using Quickorders.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quickorders.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("Signing")]
        public async Task<ActionResult> Signing(UserForLoginDto userForLogin)
        {
            var response = await _authService.Signin(userForLogin);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        
    }
}
