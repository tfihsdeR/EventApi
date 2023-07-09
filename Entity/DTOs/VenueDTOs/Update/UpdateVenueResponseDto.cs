﻿namespace Entity.DTOs.VenueDTOs.SingleVenueDTOs
{
    public class UpdateVenueResponseDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? Detail { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? GoogleMapSource { get; set; }
    }
}
