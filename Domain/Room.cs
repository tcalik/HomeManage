using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // public string Owner { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<RoomUser> RoomUsers { get; set; } = new List<RoomUser>(); 
    }
}
