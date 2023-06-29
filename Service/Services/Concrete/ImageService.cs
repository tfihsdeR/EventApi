using EventApi.Data.DTOs.ImageDTOs;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Service.Services.Abstraction;
using System.Net;

namespace Service.Services.Concrete
{
    public class ImageService : IImageService
    {
        AppDbContext context = new AppDbContext();

        public CreateImageResponseDto CreateImage(CreateImageRequestDto imageDto)
        {
            Image image = new Image()
            {
                ImageUrl = imageDto.ImageUrl,
                EventId = imageDto.EventId
            };
            context.Images.Add(image);
            context.SaveChanges();

            CreateImageResponseDto createImageResponseDto = new CreateImageResponseDto()
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                EventId = image.EventId
            };
            return createImageResponseDto;
        }

        public List<GetAllImagesResponseDto> GetAllImages()
        {
            List<GetAllImagesResponseDto> imageDto = context.Images.Select(i => new GetAllImagesResponseDto()
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                EventId = i.EventId
            }).ToList();

            return imageDto;
        }

        public GetByIdImageResponseDto GetImageById(int id)
        {
            GetByIdImageResponseDto? getByIdImageResponseDto = context.Images.Select(i => new GetByIdImageResponseDto()
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                EventId = i.EventId
            }).FirstOrDefault(dto => dto.Id == id);

            return getByIdImageResponseDto;
        }

        public HttpStatusCode RemoveImageById(int id)
        {
            Image? image = context.Images.FirstOrDefault(image => image.Id == id);
            if (image != null)
            {
                context.Images.Remove(image);
                context.SaveChanges();
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }
        }

        public UpdateImageResponseDto UpdateImage(int id, UpdateImageRequestDto imageDto)
        {
            Image? image = context.Images.FirstOrDefault(i => i.Id == id);

            UpdateImageResponseDto updateImageResponseDto = null;

            if ( image != null )
            {
                image.ImageUrl = imageDto.ImageUrl;
                image.EventId = imageDto.EventId;
                context.SaveChanges();

                updateImageResponseDto = new UpdateImageResponseDto()
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    EventId = image.EventId
                };
            }
            
            return updateImageResponseDto;
        }
    }
}
