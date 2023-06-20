using EventApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Data.Repository
{
	public class AppDbContext : DbContext
	{
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PriceBySeat> PriceBySeats { get; set; }
		public DbSet<Venue> Venues { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Event>().HasOne(e => e.Category).WithMany(c => c.Events).HasForeignKey(e => e.CategoryId);
			modelBuilder.Entity<Event>().HasOne(e => e.Venue).WithMany(v => v.Events).HasForeignKey(e => e.VenueId);
			modelBuilder.Entity<Event>().HasOne(e => e.PriceBySeat).WithMany(pbs => pbs.Events).HasForeignKey(e => e.PriceBySeatId);
			modelBuilder.Entity<Image>().HasOne(i => i.Event).WithMany(e => e.Images).HasForeignKey(i => i.EventId);

			//modelBuilder.Entity<PriceBySeat>().ToTable("PriceBySeats");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=.; database=ErdincEventApi; trusted_connection=true");
		}
	}
}
