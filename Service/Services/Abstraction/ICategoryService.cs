using EventApi.Data.DTOs.CategoryDtos;
using System.Net;

namespace Service.Services.Abstraction
{
    public interface ICategoryService
	{
		List<GetAllCategoriesResponseDto> GetAllCategories();
		GetByIdCategoryResponseDto GetCategoryById(int id);
		CreateCategoryResponseDto CreateCategory(CreateCategoryRequestDto categoryDto);
		UpdateCategoryResponseDto UpdateCategory(int id, UpdateByIdCategoryRequestDto categoryDto);
		HttpStatusCode RemoveCategoryById(int id);
	}
}
