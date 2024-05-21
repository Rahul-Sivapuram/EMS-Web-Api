using EMS.DB.Models;
using EMS.DAL;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using EMS.BAL;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EMS.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeservice;
        public EmployeesController(IEmployeeService eservice)
        {
            _employeeservice = eservice;
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ApiResponse<EmployeeDetail>> GetByID(int id)
        {
            var userId = User.FindFirstValue("Id");
            var employee = await _employeeservice.GetEmployeeById(id);
            var response = Validations.ValidateLoggedInUser(id, userId, employee, false,null);
            if (response == null)
            {
                return new ApiResponse<EmployeeDetail> { Status = "success", Data = [employee], };
            }
            else
            {
                return response;
            }
        }

        [HttpPost()]
        public async Task<ApiResponse<EmployeeDetail>> Insert(EmployeeDetail employee)
        {
            var res = await _employeeservice.AddEmployee(employee);
            return res != null ? new ApiResponse<EmployeeDetail> { Status = StatusCodes.SUCCESS.ToString(), }
            : new ApiResponse<EmployeeDetail> { Status = StatusCodes.FAIL.ToString(), ErrorCode = ErrorCodes.INSERTION_FAILED.ToString(), };
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ApiResponse<EmployeeDetail>> Update(int id, EmployeeDTO request)
        {
            var userId = User.FindFirstValue("Id");
            var response = Validations.ValidateLoggedInUser(id, userId, null, true,request);
            if (response != null)
            {
                return response;
            }

            return await _employeeservice.UpdateEmployee(id, request)
                ? new ApiResponse<EmployeeDetail> { Status = StatusCodes.SUCCESS.ToString() }
                : new ApiResponse<EmployeeDetail> { Status = StatusCodes.FAIL.ToString(), ErrorCode = ErrorCodes.UPDATE_FAILED.ToString() };
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ApiResponse<EmployeeDetail>> Delete(int id)
        {
            var userId = User.FindFirstValue("Id");
            var response = Validations.ValidateAuthorization(id, userId);

            if (response != null)
            {
                return response;
            }

            return await _employeeservice.DeleteEmployee(id)
                ? new ApiResponse<EmployeeDetail> { Status = StatusCodes.SUCCESS.ToString() }
                : new ApiResponse<EmployeeDetail> { Status = StatusCodes.FAIL.ToString(), ErrorCode = ErrorCodes.DELETION_FAILED.ToString() };
        }

        [HttpGet]
        public async Task<ApiResponse<EmployeeDetail>> Get([FromQuery] EmployeeFilter query)
        {
            var empdata = await _employeeservice.GetEmployees(query);
            return empdata.Count > 0 ? new ApiResponse<EmployeeDetail> { Status = "success", Data = empdata, }
            :new ApiResponse<EmployeeDetail>{Status = "fail",ErrorCode = ErrorCodes.NO_DATA.ToString()};
        }
    }
}