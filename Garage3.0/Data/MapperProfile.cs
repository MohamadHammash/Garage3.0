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


            CreateMap<Vehicle, VehiclesListViewModel>()
                .ForMember(
                dest => dest.IsPro,
                from => from.MapFrom(
                    v => IsPro(v.Member.ProEndDate)
                    ));

            CreateMap<VehiclesParkViewModel, Vehicle>()
                .ForMember(
                    dest => dest.Member, act => act.Ignore());

            CreateMap<Vehicle, VehiclesParkViewModel>();
               // .ReverseMap();

        }
        private static bool IsPro(DateTime date)
        {

            DateTime mbshipDate = date;
            DateTime now = DateTime.Now;
            TimeSpan difference = now.Subtract(mbshipDate);
            if (difference < TimeSpan.Zero)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
