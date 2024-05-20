using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;

namespace EMS.DAL
{
    public interface ILoginRepository
    {
        public string LoginUser(UserLogin user);
        public bool LogOut(int id);
    }
}