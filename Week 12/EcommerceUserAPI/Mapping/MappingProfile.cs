using AutoMapper;
using EcommerceUserAPI.Models;
using EcommerceUserAPI.DTOs;

namespace EcommerceUserAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<RegisterDTO, User>();
        }
    }
}