using EventApi.Data.DTOs.CategoryDtos;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		AppDbContext context = new AppDbContext();

		[HttpGet]
		public IActionResult GetAllCategories()
		{
			List<GetAllCategoriesResponseDto> categoryDtos = context.Categories.Select(c => new GetAllCategoriesResponseDto()
			{
				Id = c.Id,
				Name = c.Name
			}).ToList();

			return Ok(categoryDtos);
		}

		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			GetByIdCategoryResponseDto? categoryDto = context.Categories.Select(c => new GetByIdCategoryResponseDto()
			{
				Id= c.Id,
				Name = c.Name
			}).FirstOrDefault(c => c.Id == id);

			if (categoryDto != null)
			{
				return Ok(categoryDto);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryRequestDto categoryDto)
		{
			Category category = new Category()
			{
				Name = categoryDto.Name
			};
			context.Categories.Add(category);
			context.SaveChanges();

			CreateCategoryResponseDto categoryResponseDto = new CreateCategoryResponseDto()
			{
				Id = category.Id,
				Name = categoryDto.Name
			};
			return Ok(categoryResponseDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateByIdCategory(int id, UpdateByIdCategoryRequestDto categoryDto)
		{
			Category? category = context.Categories.FirstOrDefault(c => c.Id == id);

			if (category != null)
			{
				category.Name = categoryDto.Name;
				context.SaveChanges();

				UpdateCategoryResponseDto categoryResponseDto = new UpdateCategoryResponseDto()
				{
					Id = category.Id,
					Name = category.Name
				};
				return Ok(categoryResponseDto);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete]
		public IActionResult RemoveByIdCategory(int id)
		{
			Category? category = context.Categories.FirstOrDefault(c => c.Id == id);

			if (category != null)
			{
				context.Categories.Remove(category);
				context.SaveChanges();

				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
