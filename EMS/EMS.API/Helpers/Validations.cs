using System;
using System.Text.RegularExpressions;
using EMS.DB.Models;
using EMS.DAL;

namespace EMS.API
{
    public static class Validations
    {
        public static ApiResponse<EmployeeDetail> ValidateEmployeeRegistration(EmployeeDetail employee)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            string[] requiredFields = { employee.FirstName, employee.LastName, employee.Uid, employee.EmailId, employee.MobileNumber.ToString(), employee.Dob, employee.JoiningDate };
            string[] errorCodes = { ErrorCodes.FIRSTNAME_IS_REQUIRED.ToString(), ErrorCodes.LASTNAME_IS_REQUIRED.ToString(), ErrorCodes.EMPLOYEENUMBER_IS_REQUIRED.ToString(), ErrorCodes.EMAIL_IS_REQUIRED.ToString(), ErrorCodes.MOBILENUMBER_IS_REQUIRED_AND_GREATER_THAN_10.ToString(), ErrorCodes.DATE_OF_BIRTH_IS_REQUIRED.ToString(), ErrorCodes.JOININGDATE_IS_REQUIRED.ToString() };

            for (int i = 0; i < requiredFields.Length; i++)
            {
                if (string.IsNullOrEmpty(requiredFields[i]) || (i == 3 && !Regex.IsMatch(employee.EmailId, pattern)) || (i == 4 && employee.MobileNumber.ToString().Length != 10))
                {
                    return new ApiResponse<EmployeeDetail>() { Status = "error", ErrorCode = errorCodes[i] };
                }
            }
            return null;
        }

        public static ApiResponse<EmployeeDetail> ValidateLoggedInUser(int id, string userId, EmployeeDetail? employee, bool isUpdate,EmployeeDTO? updateEmployee)
        {
            if (employee == null && !isUpdate)
            {
                return new ApiResponse<EmployeeDetail> { Status = "fail", ErrorCode = ErrorCodes.NO_DATA.ToString() };
            }
            if (updateEmployee == null && isUpdate)
            {
                return new ApiResponse<EmployeeDetail> { Status = "fail", ErrorCode = ErrorCodes.DATA_IS_REQUIRED.ToString() };
            }
            if (id != Convert.ToInt32(userId))
            {
                return new ApiResponse<EmployeeDetail> { Status = "error", ErrorCode = ErrorCodes.UNAUTHORIZED.ToString() };
            }
            return null;
        }
        
        public static ApiResponse<EmployeeDetail> ValidateAuthorization(int id, string userId)
        {
            if (id != Convert.ToInt32(userId))
            {
                return new ApiResponse<EmployeeDetail> { Status = StatusCodes.ERROR.ToString(), ErrorCode = ErrorCodes.UNAUTHORIZED.ToString() };
            }
            return null;
        }

        public static ApiResponse<TokenModel> ValidateUserModel(UserLogin user,string token)
        {
            if (string.IsNullOrEmpty(user.email) && !string.IsNullOrEmpty(user.password))
            {
                return new ApiResponse<TokenModel> { Status = "error", ErrorCode = ErrorCodes.EMAIL_IS_REQUIRED.ToString() };
            }
            if(string.IsNullOrEmpty(user.password) && !string.IsNullOrEmpty(user.email))
            {
                return new ApiResponse<TokenModel> { Status = "error", ErrorCode = ErrorCodes.PASSWORD_IS_REQUIRED.ToString() };
            }
            if(string.IsNullOrEmpty(token))
            {
                return new ApiResponse<TokenModel> { Status = "failed", ErrorCode = ErrorCodes.LOGIN_FAILED.ToString() };
            }
            if(string.IsNullOrEmpty(user.email) && string.IsNullOrEmpty(user.password))
            {
                 return new ApiResponse<TokenModel> { Status = "error", ErrorCode = ErrorCodes.INVALID_DATA.ToString() };
            }
            return null;
        }
    }
}