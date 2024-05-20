using System;
using System.Threading.Tasks;
using EMS.BAL;
using EMS.DAL;
using EMS.DB.Models;
using EMS.DB;

namespace EMS.API.Helpers
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoleService,RoleService>();
        }
    }
}