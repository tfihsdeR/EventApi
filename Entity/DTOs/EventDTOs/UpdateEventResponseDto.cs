﻿namespace EventApi.Data.DTOs.EventDTOs
{
	public class UpdateEventResponseDto
	{
        public int Id { get; set; }
		public string? Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int VenueId { get; set; }
		public int CategoryId { get; set; }
		public int PriceBySeatId { get; set; }
	}
}