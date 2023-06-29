using EventApi.Data.DTOs.PriceBySeatDtos;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstraction;
using System.Net;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PriceBySeatController : ControllerBase
	{
		readonly IPriceBySeatService _priceBySeatService;
        public PriceBySeatController(IPriceBySeatService priceBySeatService)
        {
			_priceBySeatService = priceBySeatService;
        }

        [HttpGet]
		public IActionResult GetAllPriceBySeats()
		{
			List<GetAllPriceBySeatResponseDto> responseDto = _priceBySeatService.GetAllPriceBySeats();

			if (responseDto.Any())
			{
				return Ok(responseDto);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetByIdPriceBySeat(int id)
		{
			GetByIdPriceBySeatResponseDto? response = _priceBySeatService.GetPriceBySeatById(id);

			if (response != null)
			{
				return Ok(response);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult CreatePriceBySeat(CreatePriceBySeatRequestDto priceBySeatDto)
		{
			CreatePriceBySeatResponseDto response = _priceBySeatService.CreatePriceBySeat(priceBySeatDto);

            return Ok(response);
        }

		[HttpPut("{id}")]
		public IActionResult UpdateByIdPriceBySeat(UpdateByIdPriceBySeatRequestDto updatePriceBySeatDto, int id)
		{
			UpdatePriceBySeatResponseDto priceBySeat = _priceBySeatService.UpdatePriceBySeat(id, updatePriceBySeatDto);

			if (priceBySeat == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(priceBySeat);
			}
		}

		[HttpDelete]
		public IActionResult RemoveByIdPriceBySeat(int id)
		{
			var result = _priceBySeatService.RemovePriceBySeatById(id);

			if (result == HttpStatusCode.OK)
			{
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
