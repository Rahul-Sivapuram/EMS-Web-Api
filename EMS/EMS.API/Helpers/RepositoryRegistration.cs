using System;
using System.Threading.Tasks;
using EMS.BAL;
using EMS.DAL;
using EMS.DB.Models;
using EMS.DB;

namespace EMS.API.Helpers
{
    public class RepositoryRegistration
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

        }
    }
}