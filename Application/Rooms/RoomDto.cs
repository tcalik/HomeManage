using Application.Devices;
using Application.Profiles;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerUsername { get; set; }
        public ICollection<Profile> RoomUsers { get; set; }
        public ICollection<IndividualDeviceDto> IndividualDeviceDto { get; set; }
    }
}
