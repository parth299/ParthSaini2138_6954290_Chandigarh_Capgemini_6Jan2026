using AutoMapper;
using OrderApi.DTOs;
using OrderApi.Models;

namespace OrderApi.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(
                    dest => dest.CreatedDate,
                    opt => opt.MapFrom(
                        src => DateTime.Now));
        }
    }
}