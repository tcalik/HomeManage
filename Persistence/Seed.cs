using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Tom", UserName="tom", Email="tom@test.com"},
                    new AppUser{DisplayName = "Lau", UserName="lau", Email="lau@test.com"},
                    new AppUser{DisplayName = "Dor", UserName="dor", Email="dor@test.com"}
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Password12");
                }
            }


            if (!context.Locations.Any())
            {
                var locations = new List<Location>
                {
                    new Location {Id = new Guid("5f98e499-5e86-4b66-925c-ffb3a88d508d"), Name = "House1"},
                    new Location {Name = "Mansion"},
                    new Location {Name = "Winter Home"},
                };
                await context.Locations.AddRangeAsync(locations);
            }

            if (!context.Rooms.Any())
            {
                Guid locationId = new Guid("5f98e499-5e86-4b66-925c-ffb3a88d508d");
                var rooms = new List<Room>
                {
                    new Room {Name = "Living Room", LocationId = locationId},
                    new Room {Name = "Kitchen", LocationId = locationId},
                    new Room {Name = "Kitchen", LocationId = locationId}
                };
                await context.Rooms.AddRangeAsync(rooms);
            }


            await context.SaveChangesAsync();
        }
    }
}
