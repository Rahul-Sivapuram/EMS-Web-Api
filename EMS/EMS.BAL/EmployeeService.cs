using System;
using System.Collections.Generic;
using System.Linq;
using EMS.DB.Models;
using EMS.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EMS.BAL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<EmployeeDetail> GetEmployeeById(int id)
        {
            try
            {
                return await _employeeRepository.GetEmployee(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> AddEmployee(EmployeeDetail employee)
        {
            try
            {
                return await _employeeRepository.Add(employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        
        public async Task<bool> UpdateEmployee(int id, EmployeeDTO employee)
        {
            try
            {
                return await _employeeRepository.Update(id, employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }


        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                return await _employeeRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<EmployeeDetail>> GetEmployees(EmployeeFilter query)
        {
            try
            {
                return await _employeeRepository.Filter(query);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}