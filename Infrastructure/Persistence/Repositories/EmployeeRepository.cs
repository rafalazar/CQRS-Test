using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private readonly IConfiguration _configuration;
    
    public EmployeeRepository(DbContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _configuration = configuration;
    }

    public async Task<Employee> GetById(Guid id)
    {
        var query = DbSet.Where(e => e.Id == id);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<Employee> GetByDocument(string document)
    {
        var query = DbSet.Where(e => e.DocumentNumber.Equals(document));
        
        return await query.FirstOrDefaultAsync();
    }
}