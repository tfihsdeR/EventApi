using EventApi.Core;

namespace EventApi.Data.Entities
{
	public class Image : EntityBase
	{
        public string ImageUrl { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
