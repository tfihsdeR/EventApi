using EventApi.Data.DTOs.CategoryDtos;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstraction;
using Service.Services.Concrete;
using System.Net;

namespace EventApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public IActionResult GetAllCategories()
		{
			var categoryDtos = _categoryService.GetAllCategories();

			return Ok(categoryDtos);
		}

		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			var categoryDto = _categoryService.GetCategoryById(id);

			if (categoryDto != null)
			{
				return Ok(categoryDto);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryRequestDto categoryDto)
		{
			CreateCategoryResponseDto result = _categoryService.CreateCategory(categoryDto);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCategory(int id, UpdateByIdCategoryRequestDto categoryDto)
		{
			var categoryResponseDto = _categoryService.UpdateCategory(id, categoryDto);

			if (categoryResponseDto != null)
			{
				return Ok(categoryResponseDto);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpDelete]
		public IActionResult RemoveByIdCategory(int id)
		{
			HttpStatusCode httpStatusCode = _categoryService.RemoveCategoryById(id);

			if (httpStatusCode == HttpStatusCode.OK)
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
