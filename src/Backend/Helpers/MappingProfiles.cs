using System.Linq;
using AutoMapper;
using Backend.Dtos;
using Core.Entities;

namespace Backend.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Address
            CreateMap<AddressToCreateDto, Address>();

            // Category
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.ComponentIds, o => o.MapFrom(s => s.Components.Select(x => x.Id)));

            // Component
            CreateMap<Component, ComponentDto>();

            //Version
            CreateMap<Version, VersionDto>();

            //Device
            CreateMap<Device, DeviceDto>();
        }
    }
}