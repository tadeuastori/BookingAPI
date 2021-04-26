using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities;
using BookingAPI.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookingAPI.Infra.Data.Context
{
    public class BookingContext : DbContext
    {
        #region Properties
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        #endregion

        #region Constructors
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }
        #endregion

        #region Protected Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            LoadingSeed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected static void LoadingSeed(ModelBuilder modelBuilder)
        {
            new RoomSeed().Seed(modelBuilder.Entity<Room>());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("Active").CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    entry.Property("UpdatedAt").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion


    }
}
