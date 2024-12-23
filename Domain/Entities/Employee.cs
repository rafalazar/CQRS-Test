namespace Domain.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentNumber { get; set; }
    public decimal Salary { get; set; }

    public static class Factory
    {
        public static Employee Create(string firstName, string lastName, string documentNumber, decimal salary)
        {
            var entity = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                DocumentNumber = documentNumber,
                Salary = salary
            };
            
            return entity;
        }
    }
}