using EventApi.Data.DTOs.ImageDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		AppDbContext context = new AppDbContext();

		[HttpGet]
		public IActionResult GetAllImages()
		{
			List<GetAllImagesResponseDto> imageDto = context.Images.Select(i => new GetAllImagesResponseDto()
			{
				Id = i.Id,
				ImageUrl = i.ImageUrl,
				EventId = i.EventId
			}).ToList();

			if (imageDto.Any())
			{
				return Ok(imageDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetByIdImage(int id)
		{
			GetByIdImageResponseDto? getByIdImageResponseDto = context.Images.Select(i => new GetByIdImageResponseDto()
			{
				Id = i.Id,
				ImageUrl = i.ImageUrl,
				EventId = i.EventId
			}).FirstOrDefault(dto => dto.Id == id);

			if (getByIdImageResponseDto != null)
			{
				return Ok(getByIdImageResponseDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpPost]
		public IActionResult CreateImage(Image imageDto)
		{
			Image image = new Image()
			{
				ImageUrl = imageDto.ImageUrl,
				EventId = imageDto.EventId
			};
			context.Images.Add(image);

			CreateImageResponseDto createImageResponseDto = new CreateImageResponseDto()
			{
				Id = imageDto.Id,
				ImageUrl = imageDto.ImageUrl,
				EventId = imageDto.EventId
			};
			return Ok(createImageResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateImage(Image imageDto, int id)
		{
			Image? image = context.Images.FirstOrDefault(i => i.Id == id);
			if (image != null)
			{
				image.ImageUrl = imageDto.ImageUrl;
				image.EventId = imageDto.EventId;
				context.SaveChanges();

				UpdateImageResponseDto updateImageResponseDto = new UpdateImageResponseDto()
				{
					Id = image.Id,
					ImageUrl = image.ImageUrl,
					EventId = image.EventId
				};
				return Ok(updateImageResponseDto);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpDelete]
		public IActionResult RemoveImage(int id)
		{
			Image? image = context.Images.FirstOrDefault(image => image.Id == id);
			if (image != null)
			{
				context.Images.Remove(image);
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
