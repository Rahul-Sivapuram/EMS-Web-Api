using System;
using EMS.DAL;
using Microsoft.Extensions.Logging;


namespace EMS.BAL
{
    public class RegisterService : IRegisterService
    {
        private readonly ILogger<RegisterService> _logger;
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(ILogger<RegisterService> logger, IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
            _logger = logger;
        }

        public async Task<bool> AddUser(RegisterDTO user)
        {
            try
            {
                return await _registerRepository.RegisterUser(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}