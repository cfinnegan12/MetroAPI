using AutoMapper;
using MetroAPI.DTOs;
using MetroAPI.Models;

namespace MetroAPI.Profiles
{
    public class OperationDaysProfile : Profile
    {
        public OperationDaysProfile()
        {
            CreateMap<Journey, OperationDaysDto>();
        }
    }
}
