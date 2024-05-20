using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
namespace EMS.DAL
{
    public class EmployeeFilter
    {
        public string? Location { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public string? Manager { get; set; }
        public string? Project { get; set; }
        public string? EmployeeName { get; set; }
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10; 

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(Location) &&
                   string.IsNullOrEmpty(JobTitle) &&
                   string.IsNullOrEmpty(Department) &&
                   string.IsNullOrEmpty(Manager) &&
                   string.IsNullOrEmpty(Project) &&
                   string.IsNullOrEmpty(EmployeeName);
        }
    }
}
