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

        public string Login(UserLogin user)
        {
            try
            {
                return _loginRepository.LoginUser(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        public bool LogOut(int id)
        {
            try
            {
                return _loginRepository.LogOut(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}