using EventApi.Data.DTOs.CategoryDtos;
using EventApi.Data.DTOs.EventDTOs;
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
	}
}
