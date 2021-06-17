﻿using Quickorders.Domain.DTOS;
using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.IServices
{
    public interface IAuthService
    {
        Task<ClientResponse<UserProfileDto>> Signin(UserForLoginDto userForLogin);
    }
}
