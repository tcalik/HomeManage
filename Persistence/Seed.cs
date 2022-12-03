using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Rooms.Any()) return;

            var rooms = new List<Room>
            {
                new Room {Name = "Living Room", Owner = "John"},
                new Room {Name = "Kitchen", Owner = "John"},
                new Room {Name = "Kitchen", Owner = "Eva"}
            };
            await context.Rooms.AddRangeAsync(rooms);
            await context.SaveChangesAsync();   
        }
    }
}
