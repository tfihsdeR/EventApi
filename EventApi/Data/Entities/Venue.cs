using EventApi.Core;

namespace EventApi.Data.Entities
{
	public class Venue : EntityBase
	{
        public string City { get; set; }
        public string District { get; set; }
        public string? Detail { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? GoogleMapLink { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
