using Entity.DTOs.EventDTOs.Create;
using Entity.DTOs.EventDTOs.Get;
using Entity.DTOs.EventDTOs.Update;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Service.Services.Abstraction;
using System.Net;

namespace Service.Services.Concrete
{
    public class EventService : IEventService
	{
		AppDbContext context = new AppDbContext();

		public CreateEventResponseDto CreateEvent(CreateEventRequestDto createDto)
		{
			Event _event = new Event()
			{
				Name = createDto.Name,
				Organizor = createDto.Organizor,
				Description = createDto.Description,
				StartDate = createDto.StartDate,
				EndDate = createDto.EndDate,
				VenueId = createDto.VenueId,
				CategoryId = createDto.CategoryId
			};

			context.Events.Add(_event);
			context.SaveChanges();

			CreateEventResponseDto createEventResponseDto = new CreateEventResponseDto()
			{
				Id = _event.Id,
				Name = _event.Name,
				Organizor = _event.Organizor,
				Description = _event.Description,
				StartDate = _event.StartDate,
				EndDate = _event.EndDate,
				VenueId = _event.VenueId,
				CategoryId = _event.CategoryId
			};

			return createEventResponseDto;
		}

		public List<GetAllEventResponseDto> GetAllEvents()
		{
			List<GetAllEventResponseDto> getAllEventResponseDto = context.Events.Select(e => new GetAllEventResponseDto()
			{
				Id = e.Id,
				Name = e.Name,
				Organizor = e.Organizor,
				Description = e.Description,
				StartDate = e.StartDate,
				EndDate = e.EndDate,
				VenueId = e.VenueId,
				CategoryId = e.CategoryId
			}).ToList();

			return getAllEventResponseDto;
		}

        public GetByIdEventResponseDto GetEventById(int id)
		{
			GetByIdEventResponseDto? getByIdEventResponseDto = context.Events.Select(e => new GetByIdEventResponseDto()
			{
				Id = e.Id,
				Name = e.Name,
				Organizor = e.Organizor,
				Description = e.Description,
				StartDate = e.StartDate,
				EndDate = e.EndDate,
				VenueId = e.VenueId,
				CategoryId = e.CategoryId
			}).FirstOrDefault(dto => dto.Id == id);

			return getByIdEventResponseDto;
		}

		public HttpStatusCode RemoveEventById(int id)
		{
			Event? _event = context.Events.FirstOrDefault(_e => _e.Id == id);
			if (_event == null)
			{
				return HttpStatusCode.NotFound;
			}
			else
			{
				context.Events.Remove(_event);
				context.SaveChanges();
				return HttpStatusCode.OK;
			}
		}

		public UpdateEventResponseDto UpdateEvent(int id, UpdateEventRequestDto updateDto)
		{
			Event? _event = context.Events.FirstOrDefault(e => e.Id == id);

			UpdateEventResponseDto updateEventResponseDto = null;


            if (updateDto != null)
			{
				_event.Name = updateDto.Name;
				_event.Organizor = updateDto.Organizor;
                _event.Description = updateDto.Description;
                _event.StartDate = updateDto.StartDate;
                _event.EndDate = updateDto.EndDate;
                _event.VenueId = updateDto.VenueId;
                _event.CategoryId = updateDto.CategoryId;

                context.SaveChanges();

                updateEventResponseDto = new UpdateEventResponseDto()
                {
                    Id = _event.Id,
					Name = _event.Name,
					Organizor = _event.Organizor,
                    Description = _event.Description,
                    StartDate = _event.StartDate,
                    EndDate = _event.EndDate,
                    VenueId = _event.VenueId,
                    CategoryId = _event.CategoryId
                };
            }

			return updateEventResponseDto;
		}


        public List<GetAllEventsBySearchedKeywordInOrganizorAndNameResponseDto> GetAllEventsByKeyword(string keyword)
        {
            var response = context.Events.Where(e => e.Name.ToLower().Contains(keyword.ToLower()) || e.Organizor.ToLower().Contains(keyword.ToLower())).Select(e => new GetAllEventsBySearchedKeywordInOrganizorAndNameResponseDto()
			{
				Id = e.Id,
				Name = e.Name,
				Organizor = e.Organizor,
				Description = e.Description,
				StartDate = e.StartDate,
				EndDate = e.EndDate,
				VenueId = e.VenueId,
				CategoryId = e.CategoryId
			}).ToList();

			return response;
        }
    }
}
