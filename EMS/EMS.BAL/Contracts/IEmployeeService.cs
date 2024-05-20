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
        EmployeeDetail GetEmployeeById(int id);
        int AddEmployee(EmployeeDetail employee);
        bool UpdateEmployee(int id,EmployeeDTO employee);
        bool DeleteEmployee(int id);
        List<EmployeeDetail> GetEmployees(EmployeeFilter userquery);

    }
}