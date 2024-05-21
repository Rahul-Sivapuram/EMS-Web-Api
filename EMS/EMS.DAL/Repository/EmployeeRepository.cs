using System;
using EMS.DB;
using EMS.DB.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        public List<EmployeeDetail> Get(int pageNumber, int pageSize)
        {
            var res = _context.EmployeeDetails.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).ToList();

            return res;
        }

        public EmployeeDetail GetEmployee(int id)
        {
            var employee = _context.EmployeeDetails.FirstOrDefault(x => x.Id == id);
            if (employee is null)
            {
                return null;
            }
            return employee;
        }

        public int Add(EmployeeDetail employee)
        {
            Employee newEmp = Mapper.EDToEmployee(employee, _context.Locations.ToList(), _context.Roles.ToList(),
            _context.Departments.ToList(), _context.EmployeeDetails.ToList(), _context.Projects.ToList(),_context.Modes.ToList());
            _context.Employees.Add(newEmp);
            _context.SaveChanges();
            return employee.Id;
        }

        public bool Update(int id, EmployeeDTO request)
        {
            var res = _context.Employees.FirstOrDefault(x => x.Id == id);
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
                    res.LocationId = _context.Locations.FirstOrDefault(s => s.Name == request.Location)?.Id;
                }

                if (!string.IsNullOrEmpty(request.Role))
                {
                    res.RoleId = _context.Roles.FirstOrDefault(s => s.Name == request.Role)?.Id;
                }

                if (!string.IsNullOrEmpty(request.Department))
                {
                    res.DepartmentId = _context.Departments.FirstOrDefault(s => s.Name == request.Department)?.Id;
                }

                if (!string.IsNullOrEmpty(request.Manager))
                {
                    res.IsManager = false;
                    res.ManagerId = _context.EmployeeDetails.FirstOrDefault(s => (s.FirstName + " " + s.LastName) == request.Manager)?.Id;
                }
                else
                {
                    res.IsManager = true;
                    res.ManagerId = null;
                }

                if (!string.IsNullOrEmpty(request.Project))
                {
                    res.ProjectId = _context.Projects.FirstOrDefault(s => s.Name == request.Project)?.Id;
                }
                if (!string.IsNullOrEmpty(request.ModelStatus))
                {
                    res.ModeId = _context.Modes.FirstOrDefault(s => s.Name == request.ModelStatus).Id;
                }

                _context.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee is null)
            {
                return false;
            }
            else
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
        }

        public List<EmployeeDetail> Filter(EmployeeFilter query)
        {
            if (query == null || query.IsEmpty())
            {
                return Get(query.PageNumber, query.PageSize);
            }
            else
            {
                var queryableEmployees = _context.EmployeeDetails.AsQueryable();

                if (!string.IsNullOrEmpty(query.EmployeeName))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.FirstName.StartsWith(query.EmployeeName));
                }

                if (!string.IsNullOrEmpty(query.Location))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.Location == query.Location);
                }

                if (!string.IsNullOrEmpty(query.Department))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.Department == query.Department);
                }

                if (!string.IsNullOrEmpty(query.JobTitle))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.Role == query.JobTitle);
                }

                if (!string.IsNullOrEmpty(query.Manager))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.Manager == query.Manager);
                }

                if (!string.IsNullOrEmpty(query.Project))
                {
                    queryableEmployees = queryableEmployees.Where(emp => emp.Project == query.Project);
                }

                var filteredEmployees = queryableEmployees.ToList();


                return filteredEmployees.Count > 0
                    ? filteredEmployees.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList()
                    : null;

            }
        }

    }
}
