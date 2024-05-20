using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using EMS.DB.Models;
using EMS.DB;
namespace EMS.DAL
{
    public interface IEmployeeRepository
    {
        List<EmployeeDetail> Get(int pageNumber, int pageSize);
        EmployeeDetail GetEmployee(int id);
        int Add(EmployeeDetail employee);
        bool Update(int id, EmployeeDTO employee);
        bool Delete(int id);
        List<EmployeeDetail> Filter(EmployeeFilter query);

    }
}