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
