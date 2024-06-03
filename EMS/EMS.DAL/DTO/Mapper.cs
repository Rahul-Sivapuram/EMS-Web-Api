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
        public static Employee EDToEmployee(EmployeeDetail employee,int? LocationId,int? RoleId,int? DepartmentId,bool IsManager,int? ManagerId,int? ProjectId,int ModeId)
        {
            return CreateEmployee(employee.Uid, employee.FirstName, employee.LastName, DateOnly.Parse(employee.Dob), employee.EmailId, employee.MobileNumber, DateOnly.Parse(employee.JoiningDate), LocationId, RoleId, DepartmentId, IsManager, ManagerId, ProjectId,ModeId,employee.ProfilePic);
        }

        public static Employee RDToEmployee(RegisterDTO userDetails,int? LocationId,int? RoleId,int? DepartmentId,bool IsManager,int? ManagerId,int? ProjectId,int ModeId)
        {
            return CreateEmployee(userDetails.Uid, userDetails.FirstName, userDetails.LastName, DateOnly.Parse(userDetails.Dob), userDetails.EmailId, userDetails.MobileNumber, DateOnly.Parse(userDetails.JoiningDate), LocationId, RoleId, DepartmentId, IsManager, ManagerId, ProjectId, ModeId,userDetails.ProfilePic);
        }

        private static Employee CreateEmployee(string uid, string firstName, string lastName, DateOnly dob, string emailId, long mobileNumber, DateOnly joiningDate, int? lid, int? rid, int? did, bool isManager, int? mid, int? pid, int modeId,string profilePic)
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
                ProjectId = pid,
                ModeId = modeId,
                ProfilePic = profilePic
            };
        }
    }
}