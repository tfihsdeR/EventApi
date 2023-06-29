using EventApi.Data.DTOs.PriceBySeatDtos;
using EventApi.Data.DTOs.VenueDTOs;
using System.Net;

namespace Service.Services.Abstraction
{
    public interface IVenueService
    {
        List<GetAllVenuesResponseDto> GetAllVenues();
        GetByIdVenueResponseDto GetVenueById(int id);
        CreateVenueResponseDto CreateVenue(CreateVenueRequestDto createDto);
        UpdateVenueResponseDto UpdateVenue(int id, UpdateVenueRequestDto updateDto);
        HttpStatusCode RemoveVenueById(int id);
    }
}
