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
        public DbSet<Location> Locations { get; set; }
        public DbSet<RechangeType> RechangeTypes { get; set; }
        public DbSet<RechangeObject> RechangeObjects { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceBrand> DeviceBrands { get; set; }
        public DbSet<DeviceModel> DeviceModels { get; set; }
        public DbSet<RoomUser> RoomsUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RoomUser>(x => x.HasKey(ru => new { ru.AppUserId, ru.RoomId }));

            builder.Entity<RoomUser>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Rooms)
                .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<RoomUser>()
               .HasOne(u => u.Room)
               .WithMany(a => a.RoomUsers)
               .HasForeignKey(aa => aa.RoomId);


            builder.Entity<Location>()
            .HasMany(r => r.Rooms)
            .WithOne(l => l.Location)
            .HasForeignKey(aa => aa.LocationId);


            builder.Entity<RechangeObject>()
                .HasOne(r => r.RechangeType)
                .WithMany(o => o.RechangeObjects)
                .HasForeignKey(aa => aa.RechangeTypeId);

            builder.Entity<DeviceModel>()
                .HasOne(r => r.DeviceBrand)
                .WithMany(m => m.DeviceModels)
                .HasForeignKey(aa => aa.DeviceBrandId);

          builder.Entity<DeviceModel>()
                .HasOne(k => k.DefaultRechange)
                .WithMany(m => m.DeviceModels)
                .HasForeignKey(aa => aa.DefaultRechangeId);


            builder.Entity<DeviceModel>()
               .HasOne(r => r.DeviceType)
               .WithMany(m => m.DeviceModels)
               .HasForeignKey(aa => aa.DeviceTypeId);




        }
    }
}