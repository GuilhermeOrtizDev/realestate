using DevIO.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class UFMapping : IEntityTypeConfiguration<UFDTO>
    {
        public void Configure(EntityTypeBuilder<UFDTO> builder)
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
                .HasColumnType("varchar(2)");


            builder.ToTable("ufs");
        }
    }
}