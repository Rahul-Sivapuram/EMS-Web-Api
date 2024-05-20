using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
using EMS.DB;


namespace EMS.DAL
{
    public class RoleRepository:IRoleRepository
    {
        private readonly EmployeeDBContext _context;
        public RoleRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public bool AddRole(RoleDetail role)
        {
            if (role == null)
            {
                return false;
            }
            Role newRole = new Role()
            {
                Name = role.RoleName,
                DepartmentId = _context.Departments.FirstOrDefault(s => s.Name == role.DepartmentName)?.Id,
                LocationId = _context.Locations.FirstOrDefault(s => s.Name == role.Location)?.Id,
                Description = role.Description,
                EmployeeId = _context.Employees.FirstOrDefault(s => (s.FirstName+" "+s.LastName) == role.EmployeeName)?.Id,
            };
            if (!_context.Roles.Any(s => s.Name == role.RoleName))
            {
                _context.Roles.Add(newRole);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}