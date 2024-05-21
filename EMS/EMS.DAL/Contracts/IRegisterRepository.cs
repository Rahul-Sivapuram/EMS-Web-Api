using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DB.Models;

namespace EMS.DAL
{
    public interface IRegisterRepository
    {
        public Task<bool> RegisterUser(RegisterDTO user);
    }
}