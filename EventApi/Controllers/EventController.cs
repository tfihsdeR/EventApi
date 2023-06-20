using EventApi.Data.DTOs.EventDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{
		AppDbContext context = new AppDbContext();

		[HttpGet]
		public IActionResult GetAllEvents()
		{
			List<GetAllEventResponseDto> getAllEventResponseDto = context.Events.Select(e => new GetAllEventResponseDto()
			{
				Id = e.Id,
				Description = e.Description,
				StartDate = e.StartDate,
				EndDate = e.EndDate,
				VenueId = e.VenueId,
				CategoryId = e.CategoryId,
				PriceBySeatId = e.PriceBySeatId
			}).ToList();

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
		public IActionResult GetByIdEvent(int id)
		{
			GetByIdEventResponseDto? getByIdEventResponseDto = context.Events.Select(e => new GetByIdEventResponseDto()
			{
				Id = e.Id,
				Description = e.Description,
				StartDate = e.StartDate,
				EndDate = e.EndDate,
				VenueId = e.VenueId,
				CategoryId = e.CategoryId,
				PriceBySeatId = e.PriceBySeatId
			}).FirstOrDefault(dto => dto.Id == id);

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
			Event _event = new Event()
			{
				Description = eventDto.Description,
				StartDate = eventDto.StartDate,
				EndDate = eventDto.EndDate,
				VenueId = eventDto.VenueId,
				CategoryId = eventDto.CategoryId,
				PriceBySeatId = eventDto.PriceBySeatId
			};

			context.Events.Add(_event);
			context.SaveChanges();

			CreateEventResponseDto createEventResponseDto = new CreateEventResponseDto()
			{
				Id = _event.Id,
				Description = _event.Description,
				StartDate = _event.StartDate,
				EndDate = _event.EndDate,
				VenueId = _event.VenueId,
				CategoryId = _event.CategoryId,
				PriceBySeatId = _event.PriceBySeatId
			};

			return Ok(createEventResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateEvent(UpdateEventRequestDto eventDto, int id)
		{
			Event? _event = context.Events.FirstOrDefault(e => e.Id == id);
			if (_event == null)
			{
				return NoContent();
			}
			else
			{
				_event.Description = eventDto.Description;
				_event.StartDate = eventDto.StartDate;
				_event.EndDate = eventDto.EndDate;
				_event.VenueId = eventDto.VenueId;
				_event.CategoryId = eventDto.CategoryId;
				_event.PriceBySeatId = eventDto.PriceBySeatId;

				UpdateEventResponseDto updateEventResponseDto = new UpdateEventResponseDto()
				{
					Id = _event.Id,
					Description = _event.Description,
					StartDate = _event.StartDate,
					EndDate = _event.EndDate,
					VenueId = _event.VenueId,
					CategoryId = _event.CategoryId,
					PriceBySeatId = _event.PriceBySeatId
				};

				return Ok(updateEventResponseDto);
			}
		}

		[HttpDelete]
		public IActionResult RemoveEvent(int id)
		{
			Event? _event = context.Events.FirstOrDefault(_e => _e.Id == id);
			if ( _event == null)
			{
				return NoContent() ;
			}
			else
			{
				context.Events.Remove( _event );
				return Ok();
			}
		}
	}
}
