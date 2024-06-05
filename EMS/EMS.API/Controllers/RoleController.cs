using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMS.BAL;
using EMS.DB.Models;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<ApiResponse<RoleDetail>> AddRole([FromBody] RoleDetail role)
        {
            var res =await _roleService.Insert(role);
            if(res)
            {
                return new ApiResponse<RoleDetail>
                {
                     Status = "success"
                };
            }
            else
            {
                return new ApiResponse<RoleDetail>
                {
                     Status = "fail",
                     ErrorCode = ErrorCodes.INSERTION_FAILED.ToString()
                };
            }
        }
    }
}