using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Domain.Common;
using ContactKeeper.Domain.Entities;
using ContactKeeper.Infrastructure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ContactKeeper.Infrastructure.Persistence;

public class ApplicationDbContext :DbContext,  IApplicationDbContext
{
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext( IDomainEventService domainEventService) 
        =>   _domainEventService = domainEventService;


    /// this is where the old models are
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<ContactCategory> ContactCategories { get; set; }
    public DbSet<ContactEntity> ContactEntities { get; set; }
    public DbSet<ContactPerson> ContactPeople { get; set; }
    public DbSet<ContactPreference> ContactPreferences { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<User> Users { get; set; }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        await DispatchEvents();
        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder) => 
        base.OnModelCreating(builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()));

    private async Task DispatchEvents()
    {
        while (true)
        {
            var domainEventEntity = ChangeTracker
                .Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .FirstOrDefault(domainEvent => !domainEvent.IsPublished);
            if (domainEventEntity == null) break;
            domainEventEntity.IsPublished = true;
            await _domainEventService.Publish(domainEventEntity);
        }
    }
}
