namespace Application.Employees.Queries;

public class FindResult
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentNumber { get; set; }
    public decimal Salary { get; set; }
}