using EventApi.Core;

namespace EventApi.Data.Entities
{
	public class Event : EntityBase
	{
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VenueId { get; set; }
        public int CategoryId { get; set; }
        public int PriceBySeatId { get; set; }

        public Venue Venue { get; set; }
        public Category Category { get; set; }
        public PriceBySeat PriceBySeat { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
