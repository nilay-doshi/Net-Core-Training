using System;
using System.Collections.Generic;

namespace demo_EntityFramework_API_2.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public float? EmployeeSalary { get; set; }

    public string EmployeeGender { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string? EmployeeAge { get; set; }

    public virtual Department Department { get; set; } = null!;
}
