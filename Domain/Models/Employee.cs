namespace Domain.Models;

public class Employee
{
    public int Id {get; set;}
    public string ? FirstName {get; set;}
    public string ? LastName {get; set;}
    public string ? Email {get; set;}
    public string ? Phone {get; set;}
    public DateTime Hiredate {get; set;}
    public decimal Salary {get; set;}
    public bool IsActive {get; set;}
    public int DepartmentId {get; set;}
    public int PositionId {get; set;}
      
}
