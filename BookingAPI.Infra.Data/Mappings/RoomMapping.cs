using BookingAPI.Domain.Entities;
using BookingAPI.Infra.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAPI.Infra.Data.Mappings
{
    public class RoomMapping : BaseEntityMap<Room>, IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            BaseConfigure(builder);

            builder.ToTable("rooms");

            builder.Property(r => r.Number)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(r => r.Description)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Type)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
