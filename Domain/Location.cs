using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
