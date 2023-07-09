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
                Name = "Kuruçeşme Açık Hava Konser Alanı",
                Id = 1,
				City = "İstanbul",
				District = "Beşiktaş",
				Detail = "Ortaköy, Muallim Naci Cd. No:50, 34347",
                GoogleMapSource = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3008.789539475529!2d29.0338329!3d41.0517313!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab7e68aa724f3%3A0xecbfca61072268cc!2zS3VydcOnZcWfbWUgQcOnxLFrIEhhdmEgS29uc2VyIEFsYW7EsQ!5e0!3m2!1str!2str!4v1688807271405!5m2!1str!2str"
            },
            new Venue()
            {
                Name = "Cemal Resiş Bey Konser Salonu",
                Id = 2,
                City = "İstanbul",
                District = "Şişli",
                Detail = "Harbiye, Dar'ül Bedayi Cad No:6, 34371",
                GoogleMapSource = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d24071.640092972375!2d28.9520605!3d41.0481129!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab70d190ad437%3A0x6512439e9fc9cf24!2sCemal%20Re%C5%9Fit%20Rey%20Konser%20Salonu!5e0!3m2!1str!2str!4v1688807461722!5m2!1str!2str"
            },
			// ART GALERY
			new Venue()
			{
                Name = "VENÜS Sanat Galerisi",
                Id = 3,
				City = "İstanbul",
				District = "Kadıköy",
				Detail = "Göztepe, Mustafa Kaya Sokağı No:2, 34730",
				GoogleMapSource = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3012.0522817311316!2d29.0594707!3d40.980336!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cac7900c7543f1%3A0x4e07fed89a02649d!2sVEN%C3%9CS%20Sanat%20Galerisi!5e0!3m2!1str!2str!4v1688807497270!5m2!1str!2str"
            },
            new Venue()
			{
                Name = "Schneidertempel Sanat Merkezi",
				Id = 4,
				City = "İstanbul",
				District = "Beyoğlu",
				Detail = "Bereketzade, Bankalar Cad./felek Sok. No:1, 34421",
				GoogleMapSource = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d6020.10591769681!2d28.9715631!3d41.0240973!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab9e7c58af4e5%3A0x2dcdd01a3c1cc35!2sSchneidertempel%20Sanat%20Merkezi!5e0!3m2!1str!2str!4v1688807528709!5m2!1str!2str"
            },
			// THEATRE
			new Venue()
			{
                Name = "Müjdat Gezen Tiyatrosu",
                Id = 5,
				City = "İstanbul",
				District = "Kadıköy",
				Detail = "Osmanağa, Kırtasiyeci Sk. No:46, 34714",
				GoogleMapSource = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d96436.80988374872!2d28.9755196!3d40.9453306!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab868ab8c94db%3A0x934e3913b6413bef!2sM%C3%BCjdat%20Gezen%20Tiyatrosu!5e0!3m2!1str!2str!4v1688807560452!5m2!1str!2str"
            },
            new Venue()
            {
                Name = "İBB Şehir Tiyatroları Musahipzade Celâl Sahnesi",
                Id = 6,
                City = "İstanbul",
                District = "Üsküdar",
                Detail = "Aziz Mahmut Hüdayi, Halk Cd. No:84, 34672",
                GoogleMapSource = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d192763.41949594917!2d28.6002293!3d40.983048!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab8264b413551%3A0xb8f9f2cf89b84160!2s%C4%B0BB%20%C5%9Eehir%20Tiyatrolar%C4%B1%20Musahipzade%20Cel%C3%A2l%20Sahnesi!5e0!3m2!1str!2str!4v1688807590741!5m2!1str!2str"
            });

			modelBuilder.Entity<Event>().HasData(
			// CONCERT
			new Event()
			{
				Id = 1,
				Name = "Tarkan Concert",
                Organizor = "Tarkan",
				StartDate = new DateTime(2023, 7, 13),
				EndDate = new DateTime(2023, 7, 15),
				VenueId = 1,
				CategoryId = 3,
                Description = "Tarkan Concert at Kuruçeşme Açık Hava Konser Alanı."
            },
			new Event()
			{
				Id = 2,
				Name = "Jason Derulo Concert",
                Organizor = "Jason Derulo",
                StartDate = new DateTime(2023, 7, 16),
				EndDate = new DateTime(2023, 7, 19),
				VenueId = 2,
				CategoryId = 3,
                Description = "Jason Derulo Concert at Cemal Resiş Bey Konser Salonu."
            },
			new Event()
			{
				Id = 3,
				Name = "Şebnem Ferah Concert",
                Organizor = "Şebnem Ferah",
                StartDate = new DateTime(2023, 9, 10),
				EndDate = new DateTime(2023, 9, 15),
				VenueId = 2,
				CategoryId = 3,
                Description = "Şebnem Ferah Concert at Cemal Reşit Rey Konser Salonu."
            },
			// ART GALERY
			new Event()
			{
				Id = 4,
				Name = "Leonardo da Vinci Art Galery",
                Organizor = "Topyekün Art Galery",
				StartDate = new DateTime(2023, 8, 21),
				EndDate = new DateTime(2023, 8, 30),
				VenueId = 3,
				CategoryId = 2,
                Description = "Leonardo da Vinci Art Galery at VENÜS Sanat Galerisi."
            },
            new Event()
            {
                Id = 5,
                Name = "Naruto Art Galery",
                Organizor = "Masashi Kishimoto",
                StartDate = new DateTime(2023, 10, 11),
                EndDate = new DateTime(2023, 10, 27),
                VenueId = 4,
                CategoryId = 2,
                Description = "Naruto Art Galery at Schneidertempel Sanat Merkezi."
            },
            // THEATRE
            new Event()
            {
                Id = 6,
                Name = "Hamlet Theatre",
                Organizor = "10. Sokak Tiyatrosu",
                StartDate = new DateTime(2023, 9, 20),
                EndDate = new DateTime(2023, 10, 2),
                VenueId = 5,
                CategoryId = 1,
                Description = "Hamlet Theatre at Müjdat Gezen Tiyatrosu."
            },
            new Event()
            {
                Id = 7,
                Name = "Tempest Theatre",
                Organizor = "İstanbul Belediyesi",
                StartDate = new DateTime(2023, 8, 10),
                EndDate = new DateTime(2023, 8, 21),
                VenueId = 6,
                CategoryId = 1,
                Description = "Tempest Theatre at İBB Şehir Tiyatroları Musahipzade Celâl Sahnesi."
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

            modelBuilder.Entity<Image>().HasData(
            // CONCERT
            new Image()
            {
                Id = 1,
                ImageUrl = "https://i2.sdacdn.com/haber/2022/09/10/izmir-de-2-milyon-insani-costuran-tarkan-dunya-15263959_8699_m.jpg",
                EventId = 1
            },
            new Image()
            {
                Id = 2,
                ImageUrl = "https://www.indyturk.com/sites/default/files/styles/1368x911/public/article/main_image/2022/09/10/1008296-2147193470.jpg?itok=Yj-6bOHU",
                EventId = 1
            },
            new Image()
            {
                Id = 3,
                ImageUrl = "https://i4.hurimg.com/i/hurriyet/75/0x0/6319fd174e3fe02f6483d47d.jpg",
                EventId = 1
            },
            new Image()
            {
                Id = 4,
                ImageUrl = "https://www.billboard.com/wp-content/uploads/media/EMA-2015-Jason-Derulo-Performance-BIllboard-650.jpg?w=650",
                EventId = 2
            },
            new Image()
            {
                Id = 5,
                ImageUrl = "https://www.regnumhotels.com/media/b4scwtmn/regnumcarya-jasenderulo-banner.jpg",
                EventId = 2
            },
            new Image()
            {
                Id = 6,
                ImageUrl = "https://i.ytimg.com/vi/U7y6257_0kQ/maxresdefault.jpg",
                EventId = 2
            },
            new Image()
            {
                Id = 7,
                ImageUrl = "https://www.bizimizmir.net/images_haberler/2018/10/31/haber-2018-10-30-1540931409354-sebnem.jpg",
                EventId = 3
            },
            new Image()
            {
                Id = 8,
                ImageUrl = "https://i2.milimaj.com/i/milliyet/75/0x0/6318c4ef86b24504a4ff1a93.jpg",
                EventId = 3
            },
            new Image()
            {
                Id = 9,
                ImageUrl = "https://www.denizliekspres.com.tr/images/haberler/2017/05/sebnem-ferah-konseri-iptal.jpg",
                EventId = 3
            },
            // ART GALERY
            new Image()
            {
                Id = 10,
                ImageUrl = "https://bayaiyi.com/wp-content/uploads/2017/01/Mona-Lisa-Leonardo-da-Vinci-1.jpg",
                EventId = 4
            },
            new Image()
            {
                Id = 11,
                ImageUrl = "https://i4.hurimg.com/i/hurriyet/75/1200x675/612eda5f4e3fe00c40fa733d.jpg",
                EventId = 4
            },
            new Image()
            {
                Id = 12,
                ImageUrl = "https://wp.oggusto.com/wp-content/uploads/2022/07/leonardo-da-vinci-hayati-eserleri-ve-bilinmeyenleri.webp",
                EventId = 4
            },
            new Image()
            {
                Id = 13,
                ImageUrl = "https://70f186a60af817fe0731-09dac41207c435675bfd529a14211b5c.ssl.cf1.rackcdn.com/assets/attachments_p/000/071/598/size500_Rebecca_shieh_naruto_approval.jpg",
                EventId = 5
            },
            new Image()
            {
                Id = 14,
                ImageUrl = "https://www.gotokyo.org/en/spot/ev290/images/main.jpg",
                EventId = 5
            },
            new Image()
            {
                Id = 15,
                ImageUrl = "https://www.gotokyo.org/en/spot/ev290/images/main.jpg",
                EventId = 5
            },
            // THEATRE
            new Image()
            {
                Id = 16,
                ImageUrl = "https://i.ytimg.com/vi/Oq5HKX1vicM/maxresdefault.jpg",
                EventId = 6
            },
            new Image()
            {
                Id = 17,
                ImageUrl = "https://media.americanshakespearecenter.com/app/uploads/2017/10/16191919/hamlet_2018_web1.jpg",
                EventId = 6
            },
            new Image()
            {
                Id = 18,
                ImageUrl = "https://mdtheatreguide.com/wp-content/uploads/2018/01/HAMLET2018_0073-e1517186502587-550x348.jpg",
                EventId = 6
            },
            new Image()
            {
                Id = 19,
                ImageUrl = "https://www.theoldglobe.org/link/beaa065ced414a8a8760da8c048cfbd8.aspx?id=30870",
                EventId = 7
            },
            new Image()
            {
                Id = 20,
                ImageUrl = "https://i8a4b7e5.stackpathcdn.com/wp-content/uploads/2017/07/the-tempest-topher-mcgrillis-1.jpg",
                EventId = 7
            });
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=ErdincEventApi; trusted_connection=true");
		}
	}
}
