using System;
using System.Collections.Generic;

namespace EMS.DB.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? DepartmentId { get; set; }

    public int? LocationId { get; set; }

    public string? Description { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Department? Department { get; set; }
    
    public virtual Location? Location { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
