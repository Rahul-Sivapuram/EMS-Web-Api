using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMS.DAL;
using EMS.BAL;

namespace EMS.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        public readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost()]
        public ApiResponse<RegisterDTO> RegisterUser(RegisterDTO user)
        {
                var res = _registerService.AddUser(user);
                return res ? new ApiResponse<RegisterDTO> { Status = StatusCodes.SUCCESS.ToString(), } 
                :new ApiResponse<RegisterDTO> { Status = StatusCodes.FAIL.ToString(), ErrorCode = ErrorCodes.REGISTRATION_FAILED.ToString() };
          
        }
    }
}