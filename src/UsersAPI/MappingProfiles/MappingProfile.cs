using AutoMapper;
using Core.Entities;
using UsersAPI.DTOs;

namespace UsersAPI.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, ReturnUserDTO>();
        }
    }
}
