using EventApi.Core;

namespace EventApi.Data.Entities
{
	public class PriceBySeat : EntityBase
	{
        public decimal? StandardSeatPrice { get; set; }
        public decimal? VIPSeatPrice { get; set; }
        public decimal? PremiumSeatPrice { get; set; }
        public decimal? SinglePrice { get; set; }
        public bool IsStudent { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}