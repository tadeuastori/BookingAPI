using BookingAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using static BookingAPI.Domain.Enums.Enumerators;

namespace BookingAPI.Infra.Data.Seeds
{
    public class RoomSeed
    {
        public void Seed(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(
                new Room { Id = Guid.NewGuid(), Number = 1, Description = "Room for Rent", Type = RoomType.Standard, Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
                );
        }
    }
}
