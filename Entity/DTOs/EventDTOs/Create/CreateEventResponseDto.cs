﻿namespace Entity.DTOs.EventDTOs.Create
{
    public class CreateEventResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Organizor { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VenueId { get; set; }
        public int CategoryId { get; set; }
    }
}