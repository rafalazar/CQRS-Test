using Domain.Entities;

namespace Domain.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetById(Guid id);
    Task<Employee> GetByDocument(string document);
}