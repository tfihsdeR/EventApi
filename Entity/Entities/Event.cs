using EventApi.Core;

namespace EventApi.Data.Entities
{
	public class Event : EntityBase
	{
        public string Name { get; set; }
        public string? Organizor { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VenueId { get; set; }
        public int CategoryId { get; set; }

        public Venue Venue { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<PriceBySeat> PriceBySeats { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
