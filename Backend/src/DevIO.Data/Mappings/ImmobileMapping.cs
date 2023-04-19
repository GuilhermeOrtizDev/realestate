using DevIO.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ImmobileMapping : IEntityTypeConfiguration<ImmobileDTO>
    {
        public void Configure(EntityTypeBuilder<ImmobileDTO> builder)
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

            builder.Property(c => c.Reference)
                .HasColumnName("reference")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasIndex(p => p.Reference)
                .IsUnique();

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(1000)");

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("decimal");

            builder.Property(c => c.AddressId)
                .HasColumnName("address_id");

            builder.HasOne(c => c.Address)
                .WithOne(a => a.Immobile);

            builder.ToTable("immobiles");
        }
    }
}