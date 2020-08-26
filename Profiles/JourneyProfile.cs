using AutoMapper;
using MetroAPI.DTOs;
using MetroAPI.Models;

namespace MetroAPI.Profiles
{
    public class JourneyProfile : Profile
    {
        public JourneyProfile()
        {
            CreateMap<Journey, JourneyReadDto>();
        }
    }
}
