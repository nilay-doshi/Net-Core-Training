using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace demo_EntityFramework_API_2.Models;

public partial class Department
{
    [JsonIgnore]
    public int DepartmentId { get; set; }
    [JsonIgnore]
    public string? DepartmentName { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Employee>? Employees { get; set; } = new List<Employee>();
}
