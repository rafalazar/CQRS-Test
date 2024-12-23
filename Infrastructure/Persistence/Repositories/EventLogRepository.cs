using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repositories;

public class EventLogRepository : Repository<EventLog>, IEventLogRepository
{
    private readonly IConfiguration _configuration;
    
    public EventLogRepository(DbContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _configuration = configuration;
    }
}