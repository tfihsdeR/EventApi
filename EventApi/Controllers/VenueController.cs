﻿using Entity.DTOs.VenueDTOs.Create;
using Entity.DTOs.VenueDTOs.Get;
using Entity.DTOs.VenueDTOs.SingleVenueDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstraction;
using System.Net;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class VenueController : ControllerBase
	{
        readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
		public IActionResult GetAllVenues()
		{
			List<GetAllVenuesResponseDto> getAllVenuesResponseDtos = _venueService.GetAllVenues();

			if (getAllVenuesResponseDtos.Any())
			{
				return Ok(getAllVenuesResponseDtos);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetVenueById(int id)
		{
			GetByIdVenueResponseDto? getByIdVenueResponseDto = _venueService.GetVenueById(id);

			if (getByIdVenueResponseDto != null)
			{
				return Ok(getByIdVenueResponseDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpPost]
		public IActionResult CreateVenue(CreateVenueRequestDto createVenueRequestDto)
		{
			CreateVenueResponseDto createVenueResponseDto = _venueService.CreateVenue(createVenueRequestDto);
			return Ok(createVenueResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateVenue(UpdateVenueRequestDto updateVenueRequestDto, int id)
		{
			var result = _venueService.UpdateVenue(id, updateVenueRequestDto);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpDelete]
		public IActionResult RemoveVenueById(int id)
		{
			var result = _venueService.RemoveVenueById(id);
			if (result == HttpStatusCode.OK)
			{
				return Ok(result);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("venues/{eventId}")]
		public IActionResult GetAllVenuesByEventId(int eventId)
		{
			var result = _venueService.GetAllVenuesByEventId(eventId);
			if (result.Any())
			{
				return Ok(result);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("venue/{keyword}")]
		public IActionResult GetAllVenuesByString(string keyword)
		{
			var response = _venueService.GetAllVenuesByString(keyword);
			if (response.Any())
			{
				return Ok(response);
			}
			else
			{
				return NoContent();
			}
		}
    }
}
