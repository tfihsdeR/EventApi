using Entity.DTOs.ImageDTOs.Get;
using Entity.DTOs.VenueDTOs.Create;
using Entity.DTOs.VenueDTOs.Get;
using Entity.DTOs.VenueDTOs.SingleVenueDTOs;
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

        List<GetAllVenuesByEventIdResponseDto> GetAllVenuesByEventId(int eventId);
        List<GetAllVenuesByStringByEventNameAndOrganizorResponseDto> GetAllVenuesByString(string keyword);
    }
}
