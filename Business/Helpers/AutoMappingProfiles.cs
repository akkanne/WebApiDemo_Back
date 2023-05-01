using AutoMapper;
using Business.Dtos;
using Entities;

namespace Business.Helpers
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Transports, TransportDto>().ReverseMap();
            CreateMap<TransportDto, Transports>().ReverseMap();
            CreateMap<VehicleDto, Vehicles>().ReverseMap();
            CreateMap<Vehicles, VehicleDto>().ReverseMap();
        }
    }
}
