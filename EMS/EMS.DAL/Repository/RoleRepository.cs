using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddRole(RoleDetail role)
        {
            if (role == null)
            {
                return false;
            }
            Role newRole = new Role()
            {
                Name = role.RoleName,
                DepartmentId = (await _context.Departments.FirstOrDefaultAsync(s => s.Name == role.DepartmentName))?.Id,
                LocationId = (await _context.Locations.FirstOrDefaultAsync(s => s.Name == role.Location))?.Id,
                Description = role.Description,
                EmployeeId = (await _context.Employees.FirstOrDefaultAsync(s => (s.FirstName+" "+s.LastName) == role.EmployeeName))?.Id,
            };
            if (!_context.Roles.Any(s => s.Name == role.RoleName))
            {
                await _context.Roles.AddAsync(newRole);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}