using Application.DeviceModels;
using Application.Devices;
using Application.RechangeObjects;
using Application.Rooms;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Room, Room>();

            CreateMap<Room, RoomDto>()
                .ForMember(d => d.OwnerUsername, o => o.MapFrom(s => s.RoomUsers.FirstOrDefault(x => x.IsOwner).AppUser.UserName))
                .ForMember(d => d.IndividualDeviceDto, o => o.MapFrom(s => s.IndividualDevices));

            CreateMap<RoomUser, Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName));

            CreateMap<RechangeObject, RechangeObjectDto>()
                .ForMember(d => d.RechangeType, o => o.MapFrom(s => s.RechangeType.Name));

            CreateMap<DeviceModel, DeviceModelDto>()
                .ForMember(d => d.DeviceType, o => o.MapFrom(s => s.DeviceType.Name))
                .ForMember(d => d.DeviceBrand, o => o.MapFrom(s => s.DeviceBrand.Name))
                .ForMember(d => d.DefaultRechange, o => o.MapFrom(s => s.DefaultRechange.Name));

            CreateMap<IndividualDevice, IndividualDeviceDto>()
                .ForMember(d => d.DeviceModel, o => o.MapFrom(s => s.DeviceModel.Name))
                .ForMember(d => d.DeviceRechangeObject, o => o.MapFrom(s => s.DeviceRechangeObject.Name))
                .ForMember(d => d.Room, o => o.MapFrom(s => s.Room.Name));

        }
    }
}
