using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
using EMS.DB;

namespace EMS.DAL
{
    public static class Mapper
    {
        public static Employee EDToEmployee(EmployeeDetail employee, List<Location> locations, List<Role> roles, List<Department> departments, List<EmployeeDetail> employees, List<Project> projects)
        {
            int? LocationId = locations.FirstOrDefault(s => s.Name == employee.Location)?.Id;
            int? RoleId = roles.FirstOrDefault(s => s.Name == employee.Role)?.Id;
            int? DepartmentId = departments.FirstOrDefault(s => s.Name == employee.Department)?.Id;
            bool IsManager = string.IsNullOrEmpty(employee.Manager);
            int? ManagerId = string.IsNullOrEmpty(employee.Manager) ? null : employees.FirstOrDefault(s => (employee.FirstName + " " + employee.LastName) == (employee.Manager))?.Id;
            int? ProjectId = projects.FirstOrDefault(s => s.Name == employee.Project)?.Id;


            return CreateEmployee(employee.Uid, employee.FirstName, employee.LastName, DateOnly.Parse(employee.Dob), employee.EmailId, employee.MobileNumber, DateOnly.Parse(employee.JoiningDate), LocationId, RoleId, DepartmentId, IsManager, ManagerId, ProjectId);
        }

        public static Employee RDToEmployee(RegisterDTO userDetails, List<Location> locations, List<Role> roles, List<Department> departments, List<EmployeeDetail> employees, List<Project> projects)
        {
            int? LocationId = locations.FirstOrDefault(s => s.Name == userDetails.Location)?.Id;
            int? RoleId = roles.FirstOrDefault(s => s.Name == userDetails.Role)?.Id;
            int? DepartmentId = departments.FirstOrDefault(s => s.Name == userDetails.Department)?.Id;
            bool IsManager = string.IsNullOrEmpty(userDetails.Manager);
            int? ManagerId = string.IsNullOrEmpty(userDetails.Manager) ? null : employees.FirstOrDefault(s => (userDetails.FirstName + " " + userDetails.LastName) == (userDetails.Manager))?.Id;
            int? ProjectId = projects.FirstOrDefault(s => s.Name == userDetails.Project)?.Id;


            return CreateEmployee(userDetails.Uid, userDetails.FirstName, userDetails.LastName, DateOnly.Parse(userDetails.Dob), userDetails.EmailId, userDetails.MobileNumber, DateOnly.Parse(userDetails.JoiningDate), LocationId, RoleId, DepartmentId, IsManager, ManagerId, ProjectId);
        }

        private static Employee CreateEmployee(string uid, string firstName, string lastName, DateOnly dob, string emailId, long mobileNumber, DateOnly joiningDate, int? lid, int? rid, int? did, bool isManager, int? mid, int? pid)
        {
            return new Employee()
            {
                Uid = uid,
                FirstName = firstName,
                LastName = lastName,
                Dob = dob,
                EmailId = emailId,
                MobileNumber = mobileNumber,
                JoiningDate = joiningDate,
                LocationId = lid,
                RoleId = rid,
                DepartmentId = did,
                IsManager = isManager,
                ManagerId = mid,
                ProjectId = pid
            };
        }
    }
}