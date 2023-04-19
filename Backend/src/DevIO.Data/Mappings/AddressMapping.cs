using DevIO.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<AddressDTO>
    {
        public void Configure(EntityTypeBuilder<AddressDTO> builder)
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

            builder.Property(c => c.Logradouro)
                .HasColumnName("logradouro")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Number)
                .HasColumnName("number")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .HasColumnName("cep")
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Complement)
                .HasColumnName("complement")
                .HasColumnType("varchar(250)");

            builder.Property(c => c.UFId)
                .IsRequired()
                .HasColumnName("uf_id");

            builder.Property(c => c.CityId)
                .IsRequired()
                .HasColumnName("city_id");

            builder.Property(c => c.NeighborhoodId)
                .IsRequired()
                .HasColumnName("neighborhood_id");

            builder.HasOne(c => c.UF)
                .WithMany(a => a.Address)
                .HasForeignKey(c => c.UFId);

            builder.HasOne(c => c.City)
                .WithMany(a => a.Address)
                .HasForeignKey(c => c.CityId);

            builder.HasOne(c => c.Neighborhood)
                .WithMany(a => a.Address)
                .HasForeignKey(c => c.NeighborhoodId);

            builder.ToTable("adresses");
        }
    }
}