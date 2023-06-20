namespace EventApi.Data.DTOs.ImageDTOs
{
	public class CreateImageRequestDto
	{
		public string ImageUrl { get; set; }
		public int EventId { get; set; }
	}
}
