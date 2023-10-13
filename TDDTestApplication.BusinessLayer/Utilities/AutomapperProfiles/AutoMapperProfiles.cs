using AutoMapper;
using TDDTestApplication.DataAccessLayer.Entities;
using TDDTestApplication.DTO.DTOs;

namespace TDDTestApplication.BusinessLayer.Utilities.AutomapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDTO>().ReverseMap();
            }
        }
    }
}
