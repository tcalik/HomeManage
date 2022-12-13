using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomUser> RoomsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RoomUser>(x => x.HasKey(ru => new {ru.AppUserId, ru.RoomId}));
           
            builder.Entity<RoomUser>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Rooms)
                .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<RoomUser>()
               .HasOne(u => u.Room)
               .WithMany(a => a.RoomUsers)
               .HasForeignKey(aa => aa.RoomId);



        }
    }
}