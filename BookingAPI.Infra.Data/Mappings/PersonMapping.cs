using BookingAPI.Domain.Entities;
using BookingAPI.Infra.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAPI.Infra.Data.Mappings
{
    public class PersonMapping : BaseEntityMap<Person>, IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            BaseConfigure(builder);

            builder.ToTable("persons");

            builder.Property(p => p.FullName)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(p => p.Bookings)
                .WithOne(b => b.Person)
                .HasForeignKey(fk => fk.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
