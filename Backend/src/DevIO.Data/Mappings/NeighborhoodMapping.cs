using DevIO.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class NeighborhoodMapping : IEntityTypeConfiguration<NeighborhoodDTO>
    {
        public void Configure(EntityTypeBuilder<NeighborhoodDTO> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(c => c.IsActive)
                .HasColumnName("is_active")
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.Created)
                .HasColumnName("created")
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(c => c.Updated)
                .HasColumnName("updated")
                .HasColumnType("datetime2");

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CityId)
               .HasColumnName("city_id");


            builder.HasOne(c => c.City)
                .WithMany(p => p.Neighborhoods)
                .HasForeignKey(p => p.CityId);

            builder.ToTable("neighborhoods");
        }
    }
}