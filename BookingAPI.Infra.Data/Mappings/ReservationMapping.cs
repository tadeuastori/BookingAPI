using BookingAPI.Domain.Entities;
using BookingAPI.Infra.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BookingAPI.Domain.Enums.Enumerators;

namespace BookingAPI.Infra.Data.Mappings
{
    public class ReservationMapping : BaseEntityMap<Reservation>, IEntityTypeConfiguration<Domain.Entities.Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            BaseConfigure(builder);

            builder.ToTable("reservations");

            builder.Property(b => b.CheckIn)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(b => b.CheckOut)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.ReservationCode)
                .HasColumnType("nvarchar(6)")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(b => b.Status)
                .HasDefaultValue(ReservationStatus.None)
                .HasConversion<string>()
                .IsRequired();

            builder.HasIndex(p => new { p.ReservationCode })
                .IsUnique();

            builder.HasIndex(p => new { p.PersonId, p.CheckIn, p.CheckOut })
                .IsUnique();
        }
    }
}
