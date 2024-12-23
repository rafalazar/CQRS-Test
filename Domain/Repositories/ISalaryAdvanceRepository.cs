using Domain.Entities;
using Domain.Paging;

namespace Domain.Repositories;

public interface ISalaryAdvanceRepository : IRepository<SalaryAdvanceRequest>
{
    Task<bool> UpdateSalaryAdvanceRequest(Guid salaryAdvanceId);
    Task<bool> RejectSalaryAdvanceRequest(Guid salaryAdvanceId);
    PagedResult<SalaryAdvanceRequest> GetSalaryAdvanceRequests(Guid employeeId);
}