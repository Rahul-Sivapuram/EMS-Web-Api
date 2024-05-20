using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;

namespace EMS.BAL
{
    public interface ILoginService
    {
        public string Login(UserLogin user);
        public bool LogOut(int id);
    }
}