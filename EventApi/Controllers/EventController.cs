using EventApi.Data.DTOs.EventDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstraction;
using System.Net;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{
		AppDbContext context = new AppDbContext();
		readonly IEventService _eventService;

		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		[HttpGet]
		public IActionResult GetAllEvents()
		{
			List<GetAllEventResponseDto> getAllEventResponseDto = _eventService.GetAllEvents();

			if (getAllEventResponseDto.Any())
			{
				return Ok(getAllEventResponseDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetEventById(int id)
		{
			GetByIdEventResponseDto? getByIdEventResponseDto = _eventService.GetEventById(id);

			if (getByIdEventResponseDto != null)
			{
				return Ok(getByIdEventResponseDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpPost]
		public IActionResult CreateEvent(CreateEventRequestDto eventDto)
		{
			CreateEventResponseDto createEventResponseDto = _eventService.CreateEvent(eventDto);

			return Ok(createEventResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateEvent(UpdateEventRequestDto eventDto, int id)
		{
			UpdateEventResponseDto updateEventResponseDto = _eventService.UpdateEvent(id, eventDto);
			if (updateEventResponseDto != null)
			{
				return Ok(updateEventResponseDto);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpDelete]
		public IActionResult RemoveEvent(int id)
		{
			var result = _eventService.RemoveEventById(id);
			if (result == HttpStatusCode.NotFound)
			{
				return NoContent() ;
			}
			else
			{
				return Ok();
			}
		}
	}
}
