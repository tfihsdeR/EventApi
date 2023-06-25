namespace EventApi.Data.DTOs.ImageDTOs
{
	public class GetByIdImageResponseDto
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public int EventId { get; set; }
	}
}
