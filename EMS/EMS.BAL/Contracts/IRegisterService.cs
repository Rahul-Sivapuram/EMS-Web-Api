using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DAL;

namespace EMS.BAL
{
    public interface IRegisterService
    {
        public Task<bool> AddUser(RegisterDTO user);

    }
}