using DevIO.Business.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class GalleryMapping : IEntityTypeConfiguration<GalleryDTO>
    {
        public void Configure(EntityTypeBuilder<GalleryDTO> builder)
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

            builder.Property(c => c.File)
                .HasColumnName("file")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Emphasis)
                .HasColumnName("emphasis")
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.ImmobileId)
                .HasColumnName("immobile_id");

            builder.HasOne(c => c.Immobile)
                .WithMany(p => p.Gallery)
                .HasForeignKey(p => p.ImmobileId);

            builder.ToTable("galleries");
        }
    }
}