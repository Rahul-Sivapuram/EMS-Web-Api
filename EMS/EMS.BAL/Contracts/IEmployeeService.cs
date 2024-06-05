using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using EMS.DAL;
using EMS.DB.Models;

namespace EMS.BAL
{
    public interface IEmployeeService
    {
        Task<EmployeeDetail> GetEmployeeById(int id);
        Task<int> AddEmployee(EmployeeDetail employee);
        Task<bool> UpdateEmployee(int id,EmployeeDTO employee);
        Task<bool> DeleteEmployee(int id);
        Task<List<EmployeeDetail>> GetEmployees(EmployeeFilter userquery);

    }
}