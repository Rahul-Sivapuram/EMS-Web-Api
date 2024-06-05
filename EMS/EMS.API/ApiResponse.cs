using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.API
{
    public class ApiResponse<T>
    {
        public string? Status { get; set; }
        public List<T>? Data { get; set; }
        public string? ErrorCode { get; set; }
    }
}