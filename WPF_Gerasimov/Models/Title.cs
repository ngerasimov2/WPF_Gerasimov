using System;
using System.Collections.Generic;

namespace WPF_Gerasimov.Models;

public partial class Title
{
    public int Id { get; set; }

    public string Title1 { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
