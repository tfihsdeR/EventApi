using EventApi.Data.DTOs.PriceBySeatDtos;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PriceBySeatController : ControllerBase
	{
		AppDbContext context = new AppDbContext();

		[HttpGet]
		public IActionResult GetAllPriceBySeats()
		{
			List<GetAllPriceBySeatResponseDto> responseDto = context.PriceBySeats.Select(pbc => new GetAllPriceBySeatResponseDto()
			{
				Id = pbc.Id,
				StandardSeatPrice = pbc.StandardSeatPrice,
				VIPSeatPrice = pbc.VIPSeatPrice,
				PremiumSeatPrice = pbc.PremiumSeatPrice,
				SinglePrice = pbc.SinglePrice,
				IsStudent = pbc.IsStudent
			}).ToList();

			return Ok(responseDto);
		}

		[HttpGet("{id}")]
		public IActionResult GetByIdPriceBySeat(int id)
		{
			GetByIdPriceBySeatResponseDto? response = context.PriceBySeats.Select(pbc => new GetByIdPriceBySeatResponseDto()
			{
				Id = pbc.Id,
				StandardSeatPrice = pbc.StandardSeatPrice,
				PremiumSeatPrice = pbc.PremiumSeatPrice,
				SinglePrice = pbc.SinglePrice,
				IsStudent = pbc.IsStudent
			}).FirstOrDefault(pbc => pbc.Id == id);

			if (response != null)
			{
				return Ok(response);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public IActionResult CreatePriceBySeat(CreatePriceBySeatRequestDto priceBySeatDto)
		{
			PriceBySeat priceBySeat = new PriceBySeat()
			{
				StandardSeatPrice = priceBySeatDto.StandardSeatPrice,
				VIPSeatPrice = priceBySeatDto.VIPSeatPrice,
				PremiumSeatPrice = priceBySeatDto.PremiumSeatPrice,
				SinglePrice = priceBySeatDto.SinglePrice,
				IsStudent = priceBySeatDto.IsStudent
			};

			context.PriceBySeats.Add(priceBySeat);
			context.SaveChanges();

			CreatePriceBySeatResponseDto response = new CreatePriceBySeatResponseDto()
			{
				Id = priceBySeat.Id,
				VIPSeatPrice = priceBySeat.VIPSeatPrice,
				PremiumSeatPrice = priceBySeat.PremiumSeatPrice,
				SinglePrice = priceBySeat.SinglePrice,
				IsStudent = priceBySeat.IsStudent,
				StandardSeatPrice = priceBySeat.StandardSeatPrice
			};

			return Ok(response);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateByIdPriceBySeat(UpdateByIdPriceBySeatRequestDto updatePriceBySeatDtop, int id)
		{
			PriceBySeat? priceBySeat = context.PriceBySeats.FirstOrDefault(pbc => pbc.Id == id);

			if (priceBySeat == null)
			{
				return BadRequest();
			}
			else
			{
				priceBySeat.StandardSeatPrice = updatePriceBySeatDtop.StandardSeatPrice;
				priceBySeat.VIPSeatPrice = updatePriceBySeatDtop.VIPSeatPrice;
				priceBySeat.PremiumSeatPrice = updatePriceBySeatDtop.PremiumSeatPrice;
				priceBySeat.IsStudent = updatePriceBySeatDtop.IsStudent;
				priceBySeat.SinglePrice = updatePriceBySeatDtop.SinglePrice;

				context.SaveChanges();

				UpdatePriceBySeatResponseDto responseDto = new UpdatePriceBySeatResponseDto()
				{
					Id = priceBySeat.Id,
					StandardSeatPrice = priceBySeat.StandardSeatPrice,
					VIPSeatPrice = priceBySeat.VIPSeatPrice,
					PremiumSeatPrice = priceBySeat.PremiumSeatPrice,
					IsStudent = priceBySeat.IsStudent,
					SinglePrice = priceBySeat.SinglePrice
				};

				return Ok(responseDto);
			}
		}

		[HttpDelete]
		public IActionResult RemoveByIdPriceBySeat(int id)
		{
			PriceBySeat? priceBySeat = context.PriceBySeats.FirstOrDefault(pbc => pbc.Id == id);

			if (priceBySeat != null)
			{
				context.PriceBySeats.Remove(priceBySeat);
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
