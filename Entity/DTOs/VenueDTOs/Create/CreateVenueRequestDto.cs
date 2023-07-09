namespace Entity.DTOs.VenueDTOs.Create
{
    public class CreateVenueRequestDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? Detail { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? GoogleMapSource { get; set; }
    }
}
