﻿using EventApi.Data.DTOs.EventDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
				Description = createDto.Description,
				StartDate = createDto.StartDate,
				EndDate = createDto.EndDate,
				VenueId = createDto.VenueId,
				CategoryId = createDto.CategoryId,
				PriceBySeatId = createDto.PriceBySeatId
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

			return createEventResponseDto;
		}

		public List<GetAllEventResponseDto> GetAllEvents()
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

			return getAllEventResponseDto;
		}

		public GetByIdEventResponseDto GetEventById(int id)
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
				return HttpStatusCode.OK;
			}
		}

		public UpdateEventResponseDto UpdateEvent(int id, UpdateEventRequestDto updateDto)
		{
			Event? _event = context.Events.FirstOrDefault(e => e.Id == id);
			
			_event.Description = updateDto.Description;
			_event.StartDate = updateDto.StartDate;
			_event.EndDate = updateDto.EndDate;
			_event.VenueId = updateDto.VenueId;
			_event.CategoryId = updateDto.CategoryId;
			_event.PriceBySeatId = updateDto.PriceBySeatId;

			context.SaveChanges();

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

			return updateEventResponseDto;
		}
	}
}