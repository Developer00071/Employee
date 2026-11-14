namespace Application.DTOs;

public class EmployeeDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public DateTime Hiredate { get; set; }
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    
}
