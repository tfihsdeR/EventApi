using EventApi.Data.DTOs.CategoryDtos;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Service.Services.Abstraction;
using System.Net;

namespace Service.Services.Concrete
{
	public class CategoryService : ICategoryService
	{
		AppDbContext context = new AppDbContext();

		public CreateCategoryResponseDto CreateCategory(CreateCategoryRequestDto categoryDto)
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
			return categoryResponseDto;
		}

		public List<GetAllCategoriesResponseDto> GetAllCategories()
		{
			List<GetAllCategoriesResponseDto> categoryDtos = context.Categories.Select(c => new GetAllCategoriesResponseDto()
			{
				Id = c.Id,
				Name = c.Name
			}).ToList();

			return categoryDtos;
		}

		public GetByIdCategoryResponseDto GetCategoryById(int id)
		{
			GetByIdCategoryResponseDto? categoryDto = context.Categories.Select(c => new GetByIdCategoryResponseDto()
			{
				Id = c.Id,
				Name = c.Name
			}).FirstOrDefault(c => c.Id == id);

			return categoryDto;
		}

		public HttpStatusCode RemoveCategoryById(int id)
		{
			Category? category = context.Categories.FirstOrDefault(c => c.Id == id);

			if (category != null)
			{
				context.Categories.Remove(category);
				context.SaveChanges();

				return HttpStatusCode.OK;
			}
			else
			{
				return HttpStatusCode.NotFound;
			}
		}

		public UpdateCategoryResponseDto UpdateCategory(int id, UpdateByIdCategoryRequestDto categoryDto)
		{
			Category? category = context.Categories.FirstOrDefault(c => c.Id == id);

			category.Name = categoryDto.Name;
			context.SaveChanges();

			UpdateCategoryResponseDto categoryResponseDto = new UpdateCategoryResponseDto()
			{
				Id = category.Id,
				Name = category.Name
			};
			return categoryResponseDto;
		}
	}
}
