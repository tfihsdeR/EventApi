using EventApi.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApi.Data.Entities
{
	public class PriceBySeat : EntityBase
	{
        public int EventId { get; set; }
        public decimal? StandardSeatPrice { get; set; }
        public decimal? VIPSeatPrice { get; set; }
        public decimal? PremiumSeatPrice { get; set; }
        public decimal? SinglePrice { get; set; }
        public bool IsStudent { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}