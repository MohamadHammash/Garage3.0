using AutoMapper;
using Garage3._0.Models.Entities;
using Garage3._0.Models.ViewModels.MembersViewModels;
using Garage3._0.Models.ViewModels.VehiclesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3._0.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MembersListViewModel>()
                .ForMember(
                dest => dest.FullName,
                from => from.MapFrom(m => m.FullName))
                .ForMember(
                dest => dest.VehiclesOwned,
                from => from.MapFrom(m => m.Vehicles.Count)
                );
            CreateMap<Member, MembersAddViewModel>().ReverseMap();

            CreateMap<Member, MembersDetailsViewModel>()
                .ForMember(
                dest => dest.VehiclesOwned,
                from => from.MapFrom(m => m.Vehicles.Count));


            CreateMap<Vehicle, VehiclesListViewModel>();
            CreateMap<Vehicle, VehiclesParkViewModel>().ReverseMap();


        }
    }
}
