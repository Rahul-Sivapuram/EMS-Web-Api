using System;
using EMS.DB.Models;
using EMS.DB;
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

        public bool RegisterUser(RegisterDTO user)
        {
            Employee newEmp = Mapper.RDToEmployee(user,_context.Locations.ToList(),_context.Roles.ToList(),
            _context.Departments.ToList(),_context.EmployeeDetails.ToList(),_context.Projects.ToList(),_context.Modes.ToList());
            newEmp.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 12);
            _context.Employees.Add(newEmp);
            _context.SaveChanges();
            return true;
        }
    }
}