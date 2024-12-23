using Domain.Entities;
using Domain.Paging;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repositories;

public class SalaryAdvanceRepository : Repository<SalaryAdvanceRequest>, ISalaryAdvanceRepository
{
    private readonly IConfiguration _configuration;
    
    public SalaryAdvanceRepository(DbContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _configuration = configuration;
    }

    public Task<bool> UpdateSalaryAdvanceRequest(Guid salaryAdvanceId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RejectSalaryAdvanceRequest(Guid salaryAdvanceId)
    {
        throw new NotImplementedException();
    }

    public PagedResult<SalaryAdvanceRequest> GetSalaryAdvanceRequests(Guid employeeId)
    {
        throw new NotImplementedException();
    }
}