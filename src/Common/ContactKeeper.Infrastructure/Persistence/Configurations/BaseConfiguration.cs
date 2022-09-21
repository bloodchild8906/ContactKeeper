using ContactKeeper.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactKeeper.Infrastructure.Persistence.Configurations;

public abstract class BaseConfiguration<DatabaseEntity> : IEntityTypeConfiguration<DatabaseEntity> where DatabaseEntity:AuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<DatabaseEntity> builder) 
        => builder.Ignore(e => e.DomainEvents);
}
