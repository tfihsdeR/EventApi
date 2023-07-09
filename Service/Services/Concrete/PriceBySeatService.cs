using Entity.DTOs.PriceBySeatDtos.Create;
using Entity.DTOs.PriceBySeatDtos.Get;
using Entity.DTOs.PriceBySeatDtos.Update;
using EventApi.Data.Entities;
using EventApi.Data.Repository;
using Service.Services.Abstraction;
using System.Net;

namespace Service.Services.Concrete
{
    public class PriceBySeatService : IPriceBySeatService
    {
        AppDbContext context = new AppDbContext();

        public CreatePriceBySeatResponseDto CreatePriceBySeat(CreatePriceBySeatRequestDto createDto)
        {
            PriceBySeat priceBySeat = new PriceBySeat()
            {
                StandardSeatPrice = createDto.StandardSeatPrice,
                VIPSeatPrice = createDto.VIPSeatPrice,
                PremiumSeatPrice = createDto.PremiumSeatPrice,
                SinglePrice = createDto.SinglePrice,
                IsStudent = createDto.IsStudent
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

            return response;
        }

        public List<GetAllPriceBySeatResponseDto> GetAllPriceBySeats()
        {
            List<GetAllPriceBySeatResponseDto> responseDto = context.PriceBySeats.Select(pbc => new GetAllPriceBySeatResponseDto()
            {
                Id = pbc.Id,
                StandardSeatPrice = pbc.StandardSeatPrice,
                VIPSeatPrice = pbc.VIPSeatPrice,
                PremiumSeatPrice = pbc.PremiumSeatPrice,
                SinglePrice = pbc.SinglePrice,
                IsStudent = pbc.IsStudent,
                EventId = pbc.EventId
            }).ToList();

            return responseDto;
        }

        public GetByIdPriceBySeatResponseDto GetPriceBySeatById(int id)
        {
            GetByIdPriceBySeatResponseDto? response = context.PriceBySeats.Select(pbc => new GetByIdPriceBySeatResponseDto()
            {
                Id = pbc.Id,
                StandardSeatPrice = pbc.StandardSeatPrice,
                PremiumSeatPrice = pbc.PremiumSeatPrice,
                SinglePrice = pbc.SinglePrice,
                IsStudent = pbc.IsStudent
            }).FirstOrDefault(pbc => pbc.Id == id);

            return response;
        }

        public HttpStatusCode RemovePriceBySeatById(int id)
        {
            PriceBySeat? priceBySeat = context.PriceBySeats.FirstOrDefault(pbc => pbc.Id == id);

            if (priceBySeat != null)
            {
                context.PriceBySeats.Remove(priceBySeat);
                context.SaveChanges();
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }
        }

        public UpdatePriceBySeatResponseDto UpdatePriceBySeat(int id, UpdateByIdPriceBySeatRequestDto updateDto)
        {
            PriceBySeat? priceBySeat = context.PriceBySeats.FirstOrDefault(pbc => pbc.Id == id);
            UpdatePriceBySeatResponseDto responseDto = null;

            if ( priceBySeat != null )
            {
                priceBySeat.StandardSeatPrice = updateDto.StandardSeatPrice;
                priceBySeat.VIPSeatPrice = updateDto.VIPSeatPrice;
                priceBySeat.PremiumSeatPrice = updateDto.PremiumSeatPrice;
                priceBySeat.IsStudent = updateDto.IsStudent;
                priceBySeat.SinglePrice = updateDto.SinglePrice;

                context.SaveChanges();

                responseDto = new UpdatePriceBySeatResponseDto()
                {
                    Id = priceBySeat.Id,
                    StandardSeatPrice = priceBySeat.StandardSeatPrice,
                    VIPSeatPrice = priceBySeat.VIPSeatPrice,
                    PremiumSeatPrice = priceBySeat.PremiumSeatPrice,
                    IsStudent = priceBySeat.IsStudent,
                    SinglePrice = priceBySeat.SinglePrice
                };
            }

            return responseDto;
        }



        public List<GetAllPriceBySeatsByEventIdResponseDto> GetAllPriceBySeatsByEventId(int eventId)
        {
            var response = context.PriceBySeats.Where(pbc => pbc.EventId == eventId).Select(pbc => new GetAllPriceBySeatsByEventIdResponseDto()
            {
                Id = pbc.Id,
                StandardSeatPrice = pbc.StandardSeatPrice,
                VIPSeatPrice = pbc.VIPSeatPrice,
                PremiumSeatPrice = pbc.PremiumSeatPrice,
                IsStudent = pbc.IsStudent,
                SinglePrice = pbc.SinglePrice,
                EventId = pbc.EventId
            }).ToList();

            return response;
        }
    }
}
