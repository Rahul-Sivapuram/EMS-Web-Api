using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DB.Models
{
    public partial class Mode
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}