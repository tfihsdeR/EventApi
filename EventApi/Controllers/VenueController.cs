using EventApi.Data.DTOs.VenueDTOs;
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
	}
}
