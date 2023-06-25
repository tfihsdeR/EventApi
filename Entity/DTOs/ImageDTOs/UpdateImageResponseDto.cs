namespace EventApi.Data.DTOs.ImageDTOs
{
	public class UpdateImageResponseDto
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }
		public int EventId { get; set; }
	}
}
