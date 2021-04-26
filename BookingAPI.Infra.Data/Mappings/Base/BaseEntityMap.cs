using BookingAPI.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAPI.Infra.Data.Mappings.Base
{
    public abstract class BaseEntityMap<TEntity> where TEntity : BaseEntity
    {
        public void BaseConfigure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(c => c.Active)
                .HasColumnType("bit")
                .HasConversion<bool>()
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.DeletedAt)
                .HasColumnType("datetime")
                .IsRequired(false);

            builder.Property(c => c.UpdatedAt)
                .HasColumnType("datetime")
                .IsRequired(false);
        }
    }
}
