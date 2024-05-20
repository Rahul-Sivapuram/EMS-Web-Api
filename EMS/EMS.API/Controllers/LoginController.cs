using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EMS.DB.Models;
using EMS.BAL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace EMS.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        public readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost()]
        public ApiResponse<TokenModel> SignIn([FromBody] UserLogin user)
        {
            string res = _loginService.Login(user);
            List<TokenModel> data = new List<TokenModel>() { new TokenModel() { UserEmail = user.email, UserToken = res } };

            return !string.IsNullOrEmpty(res) ? new ApiResponse<TokenModel> { Status = StatusCodes.SUCCESS.ToString(), Data = data }
            : new ApiResponse<TokenModel> { Status = StatusCodes.FAIL.ToString(), ErrorCode = ErrorCodes.LOGIN_FAILED.ToString() };
        }

    }
}