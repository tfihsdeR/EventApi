using EventApi.Data.DTOs.ImageDTOs;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstraction;
using System.Net;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
			_imageService = imageService;
        }

        [HttpGet]
		public IActionResult GetAllImages()
		{
			List<GetAllImagesResponseDto> imageDto = _imageService.GetAllImages();

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
		public IActionResult GetImageById(int id)
		{
			GetByIdImageResponseDto? getByIdImageResponseDto = _imageService.GetImageById(id);

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
		public IActionResult CreateImage(CreateImageRequestDto imageDto)
		{
			CreateImageResponseDto createImageResponseDto = _imageService.CreateImage(imageDto);
			return Ok(createImageResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateImage(UpdateImageRequestDto imageDto, int id)
		{
            UpdateImageResponseDto updateImageResponseDto = _imageService.UpdateImage(id, imageDto);

			if (updateImageResponseDto != null)
			{
                return Ok(updateImageResponseDto);
            }
			else
			{
				return NoContent();
			}
        }

		[HttpDelete]
		public IActionResult RemoveImageById(int id)
		{
			var result = _imageService.RemoveImageById(id);
			if (result == HttpStatusCode.OK)
			{
				return Ok();
			}
			else
			{
				return NoContent();
			}
		}
	}
}
