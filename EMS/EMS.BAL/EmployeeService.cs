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

        public EmployeeDetail GetEmployeeById(int id)
        {
            try
            {
                return _employeeRepository.GetEmployee(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public int AddEmployee(EmployeeDetail employee)
        {
            try
            {
                return _employeeRepository.Add(employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
        
        public bool UpdateEmployee(int id, EmployeeDTO employee)
        {
            try
            {
                return _employeeRepository.Update(id, employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }


        public bool DeleteEmployee(int id)
        {
            try
            {
                return _employeeRepository.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public List<EmployeeDetail> GetEmployees(EmployeeFilter query)
        {
            try
            {
                return _employeeRepository.Filter(query);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}