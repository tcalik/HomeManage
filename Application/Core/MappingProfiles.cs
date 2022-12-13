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
                .ForMember(d => d.OwnerUsername, o => o.MapFrom(s => s.RoomUsers.FirstOrDefault(x => x.IsOwner).AppUser.UserName));
            CreateMap<RoomUser, Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName));
        }
    }
}
