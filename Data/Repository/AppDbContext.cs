using EventApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
			//modelBuilder.Entity<Event>().HasOne(e => e.Category).WithMany(c => c.Events).HasForeignKey(e => e.CategoryId);
			//modelBuilder.Entity<Event>().HasOne(e => e.Venue).WithMany(v => v.Events).HasForeignKey(e => e.VenueId);
			//modelBuilder.Entity<Event>().HasOne(e => e.PriceBySeat).WithMany(pbs => pbs.Events).HasForeignKey(e => e.PriceBySeatId);
			//modelBuilder.Entity<Image>().HasOne(i => i.Event).WithMany(e => e.Images).HasForeignKey(i => i.EventId);

			modelBuilder.Entity<Category>().HasData(new Category()
			{
				Id = 1,
				Name = "Tiyatro"
			},
			new Category()
			{
				Id = 2,	
				Name = "Resim Galerisi"
			},
			new Category()
			{
				Id = 3,
				Name = "Konser"
			});

			modelBuilder.Entity<Venue>().HasData(
			// CONCERT	
			new Venue()
			{
				Id = 1,
				City = "İstanbul",
				District = "Beşiktaş",
				Detail = "Ortaköy, Muallim Naci Cd. No:50, 34347",
				GoogleMapLink = "https://goo.gl/maps/jDZvwyybkK4raQkk8"
            },
            new Venue()
            {
                Id = 2,
                City = "İstanbul",
                District = "Şişli",
                Detail = "Harbiye, Dar'ül Bedayi Cad No:6, 34371",
                GoogleMapLink = "https://goo.gl/maps/C86sC9z7fQiX315t5"
            },
			// ART GALERY
			new Venue()
			{
				Id = 3,
				City = "İstanbul",
				District = "Kadıköy",
				Detail = "Göztepe, Mustafa Kaya Sokağı No:2, 34730",
				GoogleMapLink = "https://goo.gl/maps/eBoJeSZVwDJqEwNy9"
            },
            new Venue()
			{
				Id = 4,
				City = "İstanbul",
				District = "Beyoğlu",
				Detail = "Bereketzade, Bankalar Cad./felek Sok. No:1, 34421",
				GoogleMapLink = "https://goo.gl/maps/vRhJh3jHQsmK6XFF8"
            },
			// THEATRE
			new Venue()
			{
				Id = 5,
				City = "İstanbul",
				District = "Kadıköy",
				Detail = "Osmanağa, Kırtasiyeci Sk. No:46, 34714",
				GoogleMapLink = "https://goo.gl/maps/ftWuewkZpPHKdVm58"
            },
            new Venue()
            {
                Id = 6,
                City = "İstanbul",
                District = "Üsküdar",
                Detail = "Aziz Mahmut Hüdayi, Halk Cd. No:84, 34672",
                GoogleMapLink = "https://goo.gl/maps/1Xo9Lin9ipx4sHCZA"
            });

			modelBuilder.Entity<Event>().HasData(
			// CONCERT
			new Event()
			{
				Id = 1,
				Name = "Tarkan Konseri",
                Organizor = "Tarkan",
				StartDate = new DateTime(2023, 7, 13),
				EndDate = new DateTime(2023, 7, 15),
				VenueId = 1,
				CategoryId = 3
			},
			new Event()
			{
				Id = 2,
				Name = "Jason Derulo Konseri",
                Organizor = "Jason Derulo",
                StartDate = new DateTime(2023, 7, 16),
				EndDate = new DateTime(2023, 7, 19),
				VenueId = 2,
				CategoryId = 3
			},
			new Event()
			{
				Id = 3,
				Name = "Şebnem Ferah Konseri",
                Organizor = "Şebnem Ferah",
                StartDate = new DateTime(2023, 9, 10),
				EndDate = new DateTime(2023, 9, 15),
				VenueId = 2,
				CategoryId = 3
			},
			// ART GALERY
			new Event()
			{
				Id = 4,
				Name = "Leonardo da Vinci Resim Sergisi",
                Organizor = "Topyekün Art Galery",
				StartDate = new DateTime(2023, 8, 21),
				EndDate = new DateTime(2023, 8, 30),
				VenueId = 3,
				CategoryId = 2
            },
            new Event()
            {
                Id = 5,
                Name = "Naruto Resim Sergisi",
                Organizor = "Masashi Kishimoto",
                StartDate = new DateTime(2023, 10, 11),
                EndDate = new DateTime(2023, 10, 27),
                VenueId = 4,
                CategoryId = 2
            },
            // THEATRE
            new Event()
            {
                Id = 6,
                Name = "Hamlet Tiyatrosu",
                Organizor = "10. Sokak Tiyatrosu",
                StartDate = new DateTime(2023, 9, 20),
                EndDate = new DateTime(2023, 10, 2),
                VenueId = 5,
                CategoryId = 1
            },
            new Event()
            {
                Id = 7,
                Name = "Fırtına Tiyatrosu",
                Organizor = "İstanbul Belediyesi",
                StartDate = new DateTime(2023, 8, 10),
                EndDate = new DateTime(2023, 8, 21),
                VenueId = 6,
                CategoryId = 1
            });

			modelBuilder.Entity<PriceBySeat>().HasData(
			// CONCERT
			new PriceBySeat()
			{
				Id = 1,
				EventId = 1,
				SinglePrice = 600,
				IsStudent = false
			},
            new PriceBySeat()
            {
                Id = 2,
                EventId = 1,
                SinglePrice = 450,
                IsStudent = true
            },
            new PriceBySeat()
            {
                Id = 3,
                EventId = 2,
                SinglePrice = 700,
                IsStudent = false
            },
            new PriceBySeat()
            {
                Id = 4,
                EventId = 2,
                SinglePrice = 550,
                IsStudent = true
            },
            new PriceBySeat()
            {
                Id = 5,
                EventId = 3,
                SinglePrice = 450,
                IsStudent = false
            },
            new PriceBySeat()
            {
                Id = 6,
                EventId = 3,
                SinglePrice = 350,
                IsStudent = true
            },
            // ART GALERY
            new PriceBySeat()
            {
                Id = 7,
                EventId = 4,
                SinglePrice = 400,
                IsStudent = false
            },
            new PriceBySeat()
            {
                Id = 8,
                EventId = 4,
                SinglePrice = 350,
                IsStudent = true
            },
            new PriceBySeat()
            {
                Id = 9,
                EventId = 5,
                SinglePrice = 600,
                IsStudent = false
            },
            new PriceBySeat()
            {
                Id = 10,
                EventId = 5,
                SinglePrice = 450,
                IsStudent = true
            },
            // THEATRE
            new PriceBySeat()
            {
                Id = 11,
                EventId = 6,
                SinglePrice = 450,
                IsStudent = false
            },
            new PriceBySeat()
            {
                Id = 12,
                EventId = 6,
                SinglePrice = 300,
                IsStudent = true
            },
            new PriceBySeat()
            {
                Id = 13,
                EventId = 7,
                SinglePrice = 500,
                IsStudent = false
            },
            new PriceBySeat()
            {
                Id = 14,
                EventId = 7,
                SinglePrice = 450,
                IsStudent = true
            });

            modelBuilder.Entity<Image>().HasData(new Image()
            {

            });
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=.; database=ErdincEventApi; trusted_connection=true");
		}
	}
}
