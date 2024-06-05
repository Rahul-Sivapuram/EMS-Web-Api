using System;
using EMS.DB.Models;
using EMS.DB;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace EMS.DAL
{
    public class RegisterRepository : IRegisterRepository
    {
        public readonly EmployeeDBContext _context;
        public RegisterRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(RegisterDTO user)
        {
            int? LocationId = (await _context.Locations.FirstOrDefaultAsync(s => s.Name == user.Location))?.Id;
            int? RoleId = (await _context.Roles.FirstOrDefaultAsync(s => s.Name == user.Role))?.Id;
            int? DepartmentId = (await _context.Departments.FirstOrDefaultAsync(s => s.Name == user.Department))?.Id;
            bool IsManager = string.IsNullOrEmpty(user.Manager);
            int? ManagerId = string.IsNullOrEmpty(user.Manager) ? null : (await _context.EmployeeDetails.FirstOrDefaultAsync(s => (user.FirstName + " " + user.LastName) == (user.Manager)))?.Id;
            int? ProjectId = (await _context.Projects.FirstOrDefaultAsync(s => s.Name == user.Project))?.Id;
            int ModeId = (await _context.Modes.FirstAsync(s => s.Name == user.ModeStatus)).Id;

            Employee newEmp = Mapper.RDToEmployee(user, LocationId, RoleId, DepartmentId, IsManager, ManagerId, ProjectId, ModeId);
            newEmp.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 12);
            await _context.Employees.AddAsync(newEmp);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}