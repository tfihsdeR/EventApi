using EventApi.Data.DTOs.PriceBySeatDtos;
using System.Net;

namespace Service.Services.Abstraction
{
    public interface IPriceBySeatService
    {
        List<GetAllPriceBySeatResponseDto> GetAllPriceBySeats();
        GetByIdPriceBySeatResponseDto GetPriceBySeatById(int id);
        CreatePriceBySeatResponseDto CreatePriceBySeat(CreatePriceBySeatRequestDto createDto);
        UpdatePriceBySeatResponseDto UpdatePriceBySeat(int id, UpdateByIdPriceBySeatRequestDto updateDto);
        HttpStatusCode RemovePriceBySeatById(int id);
    }
}
