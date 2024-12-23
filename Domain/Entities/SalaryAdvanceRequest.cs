namespace Domain.Entities;

public class SalaryAdvanceRequest : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public decimal amount { get; set; }
    public string reason { get; set; }
    public bool status { get; set; }
}