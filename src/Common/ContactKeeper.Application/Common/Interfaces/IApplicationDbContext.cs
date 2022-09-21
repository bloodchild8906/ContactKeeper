using ContactKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    DbSet<Domain.Entities.ContactCategory> ContactCategories { get; set; }
    DbSet<Domain.Entities.ContactEntity> ContactEntities { get; set; }
    DbSet<Domain.Entities.ContactPerson> ContactPeople { get; set; }
    DbSet<Domain.Entities.ContactPreference> ContactPreferences { get; set; }
    DbSet<Domain.Entities.Note> Notes { get; set; }
    DbSet<Domain.Entities.UserRole> UserRole { get; set; }
    DbSet<Domain.Entities.User> Users { get; set; }

    //todo:remove these
    DbSet<City> Cities { get; set; }

    DbSet<District> Districts { get; set; }

    DbSet<Village> Villages { get; set; }



    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
