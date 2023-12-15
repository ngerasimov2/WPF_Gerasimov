using System;
using System.Collections.Generic;

namespace WPF_Gerasimov.Models;

public partial class Employee
{
    static Employee emp;
    public static Employee CreateEmployee(int ID, string Surname, string Name, string Patronymic, int TitleID)
    {
        emp = new Employee();
        emp.Id = ID;
        emp.Surname = Surname;
        emp.Name = Name;
        emp.Patronymic = Patronymic;
        emp.TitleId = TitleID;
        emp.Telephone = "Не задано";
        emp.Email = "Не задано";
        return emp;
    }
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public int TitleId { get; set; }

    public virtual Title Title { get; set; } = null!;
}
