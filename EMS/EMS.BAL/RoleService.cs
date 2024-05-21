using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
using EMS.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EMS.BAL
{
    public class RoleService:IRoleService
    {
        private readonly ILogger<RoleService> _logger;

        private readonly IRoleRepository _roleRepository;

        public RoleService(ILogger<RoleService> logger,IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public async Task<bool> Insert(RoleDetail role)
        {
            try
            {
                return await _roleRepository.AddRole(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}