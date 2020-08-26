using AutoMapper;
using MetroAPI.DTOs;
using MetroAPI.Models;

namespace MetroAPI.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationReadDto>();
        }
    }
}
