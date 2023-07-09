using Entity.DTOs.VenueDTOs.Create;
using Entity.DTOs.VenueDTOs.Get;
using Entity.DTOs.VenueDTOs.SingleVenueDTOs;
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
                Name = createDto.Name,
                City = createDto.City,
                District = createDto.District,
                Latitude = createDto.Latitude,
                Longitude = createDto.Longitude,
                GoogleMapSource = createDto.GoogleMapSource
            };
            context.Venues.Add(venue);
            context.SaveChanges();

            CreateVenueResponseDto createVenueResponseDto = new CreateVenueResponseDto()
            {
                Name = venue.Name,
                City = venue.City,
                District = venue.District,
                Latitude = venue.Latitude,
                Longitude = venue.Longitude,
                GoogleMapSource = venue.GoogleMapSource
            };
            return createVenueResponseDto;
        }

        public List<GetAllVenuesResponseDto> GetAllVenues()
        {
            List<GetAllVenuesResponseDto> getAllVenuesResponseDtos = context.Venues.Select(v => new GetAllVenuesResponseDto()
            {
                Name = v.Name,
                Id = v.Id,
                City = v.City,
                District = v.District,
                Latitude = v.Latitude,
                Longitude = v.Longitude,
                GoogleMapSource = v.GoogleMapSource
            }).ToList();

            return getAllVenuesResponseDtos;
        }
        public GetByIdVenueResponseDto GetVenueById(int id)
        {
            GetByIdVenueResponseDto? getByIdVenueResponseDto = context.Venues.Select(v => new GetByIdVenueResponseDto()
            {
                Name = v.Name,
                Id = v.Id,
                City = v.City,
                District = v.District,
                Latitude = v.Latitude,
                Longitude = v.Longitude,
                GoogleMapSource = v.GoogleMapSource
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
                venue.Name = updateDto.Name;
                venue.City = updateDto.City;
                venue.District = updateDto.District;
                venue.Latitude = updateDto.Latitude;
                venue.Longitude = updateDto.Longitude;
                venue.GoogleMapSource = updateDto.GoogleMapSource;
                context.SaveChanges();

                updateVenueResponseDto = new UpdateVenueResponseDto()
                {
                    Name = venue.Name,
                    City = venue.City,
                    District = venue.District,
                    Latitude = venue.Latitude,
                    Longitude = venue.Longitude,
                    GoogleMapSource = venue.GoogleMapSource
                };
            }

            return updateVenueResponseDto;
        }



        public List<GetAllVenuesByEventIdResponseDto> GetAllVenuesByEventId(int eventId)
        {
            List<GetAllVenuesByEventIdResponseDto> getAllVenuesByEventIdResponseDtos = context.Events.Where(e => e.Id == eventId).Select(e => new GetAllVenuesByEventIdResponseDto()
            {
                Name = e.Name,
                Id = e.Venue.Id,
                City = e.Venue.City,
                District = e.Venue.District,
                Detail = e.Venue.Detail,
                Latitude = e.Venue.Latitude,
                Longitude = e.Venue.Longitude,
                GoogleMapSource = e.Venue.GoogleMapSource
            }).ToList();

            return getAllVenuesByEventIdResponseDtos;
        }
    }
}
