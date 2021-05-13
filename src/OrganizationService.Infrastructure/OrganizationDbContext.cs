using Microsoft.EntityFrameworkCore;
using OrganizationService.Infrastructure.Entities;

namespace OrganizationService.Infrastructure
{
    public class OrganizationDbContext : DbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options) { }

        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<OrganizationMemberEntity> OrganizationMembers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(typeof(OrganizationDbContext).Assembly);

            builder.Entity<OrganizationMemberEntity>()
                .HasKey(c => new { c.OrganizationId, c.Email });
        }
        
    }
}
