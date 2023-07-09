namespace Entity.DTOs.PriceBySeatDtos.Create
{
    public class CreatePriceBySeatRequestDto
    {
        public decimal? StandardSeatPrice { get; set; }
        public decimal? VIPSeatPrice { get; set; }
        public decimal? PremiumSeatPrice { get; set; }
        public decimal? SinglePrice { get; set; }
        public bool IsStudent { get; set; }
        public int EventId { get; set; }
    }
}
