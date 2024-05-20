using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EMS.DB.Models;
using EMS.BAL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogOutController : ControllerBase
    {

        public readonly ILoginService _loginService;
        public LogOutController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ApiResponse<TokenModel> LogOut(int id)
        {
            var userId = User.FindFirstValue("Id");
            if (id != null && userId == id.ToString())
            {
                bool res = _loginService.LogOut(id);
                return new ApiResponse<TokenModel> { Status = StatusCodes.SUCCESS.ToString() };
            }
            else
            {
                return new ApiResponse<TokenModel> { Status = StatusCodes.FAIL.ToString(), ErrorCode = ErrorCodes.UNAUTHORIZED.ToString() };
            }
        }
    }
}