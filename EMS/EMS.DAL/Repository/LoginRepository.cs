using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using EMS.DB.Models;
using EMS.DB;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace EMS.DAL
{
    public class LoginRepository : ILoginRepository
    {
        public readonly EmployeeDBContext _context;
        public readonly IConfiguration _configuration;

        public LoginRepository(EmployeeDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string LoginUser(UserLogin user)
        {
            string token = "";
            List<Employee> existingusers = _context.Employees.ToList();
            foreach (Employee i in existingusers)
            {

                if (i.EmailId == user.email && BCrypt.Net.BCrypt.Verify(user.password, i.Password))
                {
                    token = CreateToken(user, i);
                    i.IsActive = true;
                    _context.SaveChanges();
                }
            }
            return token;
        }

         public bool LogOut(int id)
        {
            List<Employee> existingusers = _context.Employees.ToList();
            foreach (Employee i in existingusers)
            {
                if (i.Id == id)
                {
                    i.IsActive = false;
                    _context.SaveChanges();
                }
            }
            return true;
        }

        private string CreateToken(UserLogin user, Employee employee)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", employee.Id.ToString()),
                new Claim(ClaimTypes.Email,employee.EmailId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}