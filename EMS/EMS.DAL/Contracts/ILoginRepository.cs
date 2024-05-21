using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.DAL
{
    public interface ILoginRepository
    {
        public Task<string> LoginUser(UserLogin user);
        public Task<bool> LogOut(int id);
    }
}