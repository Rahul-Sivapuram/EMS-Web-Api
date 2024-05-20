using System;
using System.Threading.Tasks;
using EMS.BAL;
using EMS.DAL;
using EMS.DB.Models;
using EMS.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EMS.API.Helpers
{
    public class DbContextRegistration
    {
        public static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeDBContext>();
        }
    }
}