using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactKeeper.Domain.Event;

public class ContactCategoryCreatedConfiguration : BaseConfiguration<ContactCategory>
{
    public override void Configure(EntityTypeBuilder<ContactCategory> builder)
    {
        base.Configure(builder);
        builder.Property(prop => prop.Name).IsRequired();

    }
}
