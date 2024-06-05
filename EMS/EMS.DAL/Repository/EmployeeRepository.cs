using System;
using EMS.DB;
using EMS.DB.Models;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


namespace EMS.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDetail>> Get(int pageNumber, int pageSize)
        {
            var res = await _context.EmployeeDetails.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToListAsync();
            return res;
        }

        public async Task<EmployeeDetail> GetEmployee(int id)
        {
            var employee = await _context.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (employee is null)
            {
                return null;
            }
            return employee;
        }

        public async Task<int> Add(EmployeeDetail employee)
        {
            int? LocationId = (await _context.Locations.FirstOrDefaultAsync(s => s.Name == employee.Location))?.Id;
            int? RoleId = (await _context.Roles.FirstOrDefaultAsync(s => s.Name == employee.Role))?.Id;
            int? DepartmentId = (await _context.Departments.FirstOrDefaultAsync(s => s.Name == employee.Department))?.Id;
            bool IsManager = string.IsNullOrEmpty(employee.Manager);
            int? ManagerId = string.IsNullOrEmpty(employee.Manager) ? null : (await _context.EmployeeDetails.FirstOrDefaultAsync(s => (employee.FirstName + " " + employee.LastName) == employee.Manager))?.Id;
            int? ProjectId = (await _context.Projects.FirstOrDefaultAsync(s => s.Name == employee.Project))?.Id;
            int ModeId = (await _context.Modes.FirstAsync(s => s.Name == employee.ModelStatus)).Id;

            Employee newEmp = Mapper.EDToEmployee(employee, LocationId, RoleId, DepartmentId, IsManager, ManagerId, ProjectId, ModeId);
            await _context.Employees.AddAsync(newEmp);
            await _context.SaveChangesAsync();
            return newEmp.Id;
        }

        public async Task<bool> Update(int id, EmployeeDTO request)
        {
            var res = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (res is null)
            {
                return false;
            }
            else
            {
                if (!string.IsNullOrEmpty(request.FirstName))
                {
                    res.FirstName = request.FirstName;
                }

                if (!string.IsNullOrEmpty(request.LastName))
                {
                    res.LastName = request.LastName;
                }

                if (!string.IsNullOrEmpty(request.Dob))
                {
                    res.Dob = DateOnly.Parse(request.Dob);
                }

                if (!string.IsNullOrEmpty(request.EmailId))
                {
                    res.EmailId = request.EmailId;
                }

                if (request.MobileNumber.HasValue)
                {
                    res.MobileNumber = request.MobileNumber.Value;
                }

                if (!string.IsNullOrEmpty(request.JoiningDate))
                {
                    res.JoiningDate = DateOnly.Parse(request.JoiningDate);
                }

                if (!string.IsNullOrEmpty(request.Location))
                {
                    res.LocationId = (await _context.Locations.FirstOrDefaultAsync(s => s.Name == request.Location))?.Id;
                }

                if (!string.IsNullOrEmpty(request.Role))
                {
                    res.RoleId = (await _context.Roles.FirstOrDefaultAsync(s => s.Name == request.Role))?.Id;
                }

                if (!string.IsNullOrEmpty(request.Department))
                {
                    res.DepartmentId = (await _context.Departments.FirstOrDefaultAsync(s => s.Name == request.Department))?.Id;
                }

                if (!string.IsNullOrEmpty(request.Manager))
                {
                    res.IsManager = false;
                    res.ManagerId = (await _context.EmployeeDetails.FirstOrDefaultAsync(s => (s.FirstName + " " + s.LastName) == request.Manager))?.Id;
                }
                else
                {
                    res.IsManager = true;
                    res.ManagerId = null;
                }

                if (!string.IsNullOrEmpty(request.Project))
                {
                    res.ProjectId = (await _context.Projects.FirstOrDefaultAsync(s => s.Name == request.Project))?.Id;
                }
                if (!string.IsNullOrEmpty(request.ModelStatus))
                {
                    res.ModeId = (await _context.Modes.FirstOrDefaultAsync(s => s.Name == request.ModelStatus)).Id;
                }

                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee is null)
            {
                return false;
            }
            else
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<EmployeeDetail>> Filter(EmployeeFilter query)
        {
            if (query == null || query.IsEmpty())
            {
                return await Get(query.PageNumber, query.PageSize);
            }
            else
            {
                var queryableEmployees = _context.EmployeeDetails.AsQueryable();

                if (!string.IsNullOrEmpty(query.EmployeeName))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.FirstName.StartsWith(query.EmployeeName));
                }

                if (query.Location != null && query.Location.Any())
                {
                    queryableEmployees = queryableEmployees.Where(emp => query.Location.Contains(emp.Location));
                }

                if (query.Department != null && query.Department.Any())
                {
                    queryableEmployees = queryableEmployees.Where(emp => query.Department.Contains(emp.Department));
                }

                if (query.Status != null && query.Status.Any())
                {
                    queryableEmployees = queryableEmployees.Where(emp => query.Status.Contains(emp.IsActive));
                }
              

                var filteredEmployees = await queryableEmployees
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

                return filteredEmployees;

            }
        }

    }
}
