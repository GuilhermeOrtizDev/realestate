using DevIO.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DevIO.Data.Context
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<ImmobileDTO> Immobile { get; set; }
        public DbSet<GalleryDTO> Gallery { get; set; }
        public DbSet<AddressDTO> Addresses { get; set; }
        public DbSet<UFDTO> UF { get; set; }
        public DbSet<CityDTO> City { get; set; }
        public DbSet<NeighborhoodDTO> Neighborhood { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealEstateDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                    entry.Property("IsActive").CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Updated").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public void Delete(int id)
        {

        }
    }
}