using EventApi.Data.DTOs.VenueDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Service.Services.Abstraction;
using System.Net;

namespace Service.Services.Concrete
{
    public class VenueService : IVenueService
    {
        AppDbContext context = new AppDbContext();

        public CreateVenueResponseDto CreateVenue(CreateVenueRequestDto createDto)
        {
            Venue venue = new Venue()
            {
                City = createDto.City,
                District = createDto.District,
                Latitude = createDto.Latitude,
                Longitude = createDto.Longitude,
                GoogleMapLink = createDto.GoogleMapLink
            };
            context.Venues.Add(venue);
            context.SaveChanges();

            CreateVenueResponseDto createVenueResponseDto = new CreateVenueResponseDto()
            {
                City = venue.City,
                District = venue.District,
                Latitude = venue.Latitude,
                Longitude = venue.Longitude,
                GoogleMapLink = venue.GoogleMapLink
            };
            return createVenueResponseDto;
        }

        public List<GetAllVenuesResponseDto> GetAllVenues()
        {
            List<GetAllVenuesResponseDto> getAllVenuesResponseDtos = context.Venues.Select(v => new GetAllVenuesResponseDto()
            {
                Id = v.Id,
                City = v.City,
                District = v.District,
                Latitude = v.Latitude,
                Longitude = v.Longitude,
                GoogleMapLink = v.GoogleMapLink
            }).ToList();

            return getAllVenuesResponseDtos;
        }

        public GetByIdVenueResponseDto GetVenueById(int id)
        {
            GetByIdVenueResponseDto? getByIdVenueResponseDto = context.Venues.Select(v => new GetByIdVenueResponseDto()
            {
                Id = v.Id,
                City = v.City,
                District = v.District,
                Latitude = v.Latitude,
                Longitude = v.Longitude,
                GoogleMapLink = v.GoogleMapLink
            }).FirstOrDefault(dto => dto.Id == id);

            return getByIdVenueResponseDto;
        }

        public HttpStatusCode RemoveVenueById(int id)
        {
            Venue? venue = context.Venues.FirstOrDefault(v => v.Id == id);
            if (venue != null)
            {
                context.Venues.Remove(venue);
                context.SaveChanges();
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NoContent;
            }
        }

        public UpdateVenueResponseDto UpdateVenue(int id, UpdateVenueRequestDto updateDto)
        {
            Venue? venue = context.Venues.FirstOrDefault(v => v.Id == id);
            UpdateVenueResponseDto updateVenueResponseDto = null;

            if (venue != null)
            {
                venue.City = updateDto.City;
                venue.District = updateDto.District;
                venue.Latitude = updateDto.Latitude;
                venue.Longitude = updateDto.Longitude;
                venue.GoogleMapLink = updateDto.GoogleMapLink;
                context.SaveChanges();

                updateVenueResponseDto = new UpdateVenueResponseDto()
                {
                    City = venue.City,
                    District = venue.District,
                    Latitude = venue.Latitude,
                    Longitude = venue.Longitude,
                    GoogleMapLink = venue.GoogleMapLink
                };
            }

            return updateVenueResponseDto;
        }
    }
}
