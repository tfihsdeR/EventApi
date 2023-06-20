using EventApi.Data.DTOs.VenueDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VenueController : ControllerBase
	{
		AppDbContext context = new AppDbContext();

		[HttpGet]
		public IActionResult GetAllVenues()
		{
			List<GetAllVenuesResponseDto> getAllVenuesResponseDtos = context.Venues.Select(v => new GetAllVenuesResponseDto()
			{
				Id = v.Id,
				City = v.City,
				District = v.District,
				Latitude = v.Latitude,
				Longitude = v.Longitude,
				GoogleMapLink = v.GoogleMapLink
			}).ToList();

			if (getAllVenuesResponseDtos != null)
			{
				return Ok(getAllVenuesResponseDtos);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetByIdVenue(int id)
		{
			GetByIdVenueResponseDto? getByIdVenueResponseDto = context.Venues.Select(v => new GetByIdVenueResponseDto()
			{
				Id = v.Id,
				City = v.City,
				District = v.District,
				Latitude = v.Latitude,
				Longitude = v.Longitude,
				GoogleMapLink = v.GoogleMapLink
			}).FirstOrDefault(dto => dto.Id == id);

			if (getByIdVenueResponseDto != null)
				return Ok(getByIdVenueResponseDto);
			else { return NoContent(); }
		}

		[HttpPost]
		public IActionResult CreateVenue(CreateVenueRequestDto createVenueRequestDto)
		{
			Venue venue = new Venue()
			{
				City = createVenueRequestDto.City,
				District = createVenueRequestDto.District,
				Latitude =createVenueRequestDto.Latitude,
				Longitude =createVenueRequestDto.Longitude,
				GoogleMapLink = createVenueRequestDto.GoogleMapLink
			};
			context.Venues.Add(venue);
			context.SaveChanges();

			CreateVenueResponseDto createVenueResponseDto = new CreateVenueResponseDto()
			{
				City = venue.City,
				District = venue.District,
				Latitude = venue.Latitude,
				Longitude = venue.Longitude,
				GoogleMapLink = venue.GoogleMapLink
			};
			return Ok(createVenueResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateVenue(UpdateVenueRequestDto updateVenueRequestDto, int id)
		{
			Venue? venue = context.Venues.FirstOrDefault(v  => v.Id == id);
			if (venue != null)
			{
				venue.City = updateVenueRequestDto.City;
				venue.District = updateVenueRequestDto.District;
				venue.Latitude = updateVenueRequestDto.Latitude;
				venue.Longitude = updateVenueRequestDto.Longitude;
				venue.GoogleMapLink = updateVenueRequestDto.GoogleMapLink;
				context.SaveChanges();

				UpdateVenueResponseDto updateVenueResponseDto = new UpdateVenueResponseDto()
				{
					City = venue.City,
					District = venue.District,
					Latitude = venue.Latitude,
					Longitude = venue.Longitude,
					GoogleMapLink = venue.GoogleMapLink
				};
				return Ok(updateVenueResponseDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpDelete]
		public IActionResult RemoveVenue(int id)
		{
			Venue? venue = context.Venues.FirstOrDefault(v => v.Id == id);
			if (venue != null)
			{
				context.Venues.Remove(venue);
				context.SaveChanges();
				return Ok();
			}
			else
			{
				return NoContent();
			}
		}
	}
}
