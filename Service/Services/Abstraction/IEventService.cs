using Entity.DTOs.EventDTOs.Create;
using Entity.DTOs.EventDTOs.Get;
using Entity.DTOs.EventDTOs.Update;
using System.Net;

namespace Service.Services.Abstraction
{
    public interface IEventService
    {
        List<GetAllEventResponseDto> GetAllEvents();
        GetByIdEventResponseDto GetEventById(int id);
        CreateEventResponseDto CreateEvent(CreateEventRequestDto createDto);
        UpdateEventResponseDto UpdateEvent(int id, UpdateEventRequestDto updateDto);
        HttpStatusCode RemoveEventById(int id);

        List<GetAllEventsBySearchedKeywordInOrganizorAndNameResponseDto> GetAllEventsByKeyword(string keyword);
    }
}
