using Domain.Entities;
using Infrastructure.Persistence.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class AtenaDbContext : DbContext
{
    private readonly IMediator _mediator;

    public AtenaDbContext(DbContextOptions<AtenaDbContext> options, IMediator mediator)
    {
        _mediator = mediator;
    }

    #region DbSets
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<SalaryAdvanceRequest> SalaryAdvanceRequests => Set<SalaryAdvanceRequest>();
    public DbSet<EventLog> EventLogs => Set<EventLog>();
    #endregion
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtenaDbContext).Assembly);
        modelBuilder.RemovePluralTableNameConvention();
        modelBuilder.RemoveDefaultDeleteBehavior();

        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateEntities();
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
    
    private void UpdateEntities()
    {

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Created = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                entry.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }
}