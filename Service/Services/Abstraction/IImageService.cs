using EventApi.Data.DTOs.ImageDTOs;
using System.Net;

namespace Service.Services.Abstraction
{
    public interface IImageService
    {
        List<GetAllImagesResponseDto> GetAllImages();
        GetByIdImageResponseDto GetImageById(int id);
        CreateImageResponseDto CreateImage(CreateImageRequestDto imageDto);
        UpdateImageResponseDto UpdateImage(int id, UpdateImageRequestDto imageDto);
        HttpStatusCode RemoveImageById(int id);
    }
}
