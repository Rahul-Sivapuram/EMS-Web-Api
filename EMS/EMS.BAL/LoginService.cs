using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
using EMS.DAL;
using Microsoft.Extensions.Logging;

namespace EMS.BAL
{
    public class LoginService:ILoginService
    {   
        private readonly ILogger<LoginService> _logger;
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILogger<LoginService> logger,ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository; 
            _logger = logger;
        }

        public async Task<string> Login(UserLogin user)
        {
            try
            {
                return await _loginRepository.LoginUser(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        public async Task<bool> LogOut(int id)
        {
            try
            {
                return await _loginRepository.LogOut(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}