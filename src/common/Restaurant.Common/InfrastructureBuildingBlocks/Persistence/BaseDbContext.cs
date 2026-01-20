using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Common.InfrastructureBuildingBlocks.Persistence;

public abstract class BaseDbContext : SagaDbContext
{
    protected BaseDbContext(DbContextOptions options) : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        BeforeSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        BeforeSaveChanges();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        BeforeSaveChanges();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        BeforeSaveChanges();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void BeforeSaveChanges()
    {
        // TODO userId for creation, edit, delete
        var user = Guid.NewGuid();

        var entries = ChangeTracker.Entries();
        var dateNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.Entity is IDbEntityAuditable auditableEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditableEntity.CreatedDate = dateNow;
                        auditableEntity.CreatedBy = user;
                        break;
                    case EntityState.Modified:
                        auditableEntity.UpdatedBy = user;
                        auditableEntity.UpdatedDate = dateNow;
                        break;
                }
            }

            if (entry.Entity is IDbEntityDeletable deletableEntity && entry.State == EntityState.Deleted)
            {
                deletableEntity.DeletedDate = dateNow;
                deletableEntity.IsDeleted = true;
                deletableEntity.DeletedBy = user;
                entry.State = EntityState.Modified;
            }
        }
    }
}
