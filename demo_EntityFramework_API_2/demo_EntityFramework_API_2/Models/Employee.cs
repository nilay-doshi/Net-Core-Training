using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace demo_EntityFramework_API_2.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public float? EmployeeSalary { get; set; }

    public string EmployeeGender { get; set; } = null!;


    public int DepartmentId { get; set; }
    [JsonIgnore]
    public virtual Department? Department { get; set; } = null!;
}
