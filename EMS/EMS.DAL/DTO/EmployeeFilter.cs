using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
namespace EMS.DAL
{
    public class EmployeeFilter
    {
        public IEnumerable<string>? Location { get; set; }
        public IEnumerable<string>? Department { get; set; }
        public IEnumerable<bool>? Status { get; set; }
        public string? EmployeeName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public bool IsEmpty()
        {
            return (Location == null || !Location.Any()) &&
               (Department == null || !Department.Any()) &&
               (Status == null || !Status.Any()) &&
                   string.IsNullOrEmpty(EmployeeName);
        }
    }
}
