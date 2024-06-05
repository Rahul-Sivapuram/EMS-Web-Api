using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.DB.Models;
using EMS.DB;
namespace EMS.DAL
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDetail>> Get(int pageNumber, int pageSize);
        Task<EmployeeDetail> GetEmployee(int id);
        Task<int> Add(EmployeeDetail employee);
        Task<bool> Update(int id, EmployeeDTO employee);
        Task<bool> Delete(int id);
        Task<List<EmployeeDetail>> Filter(EmployeeFilter query);

    }
}