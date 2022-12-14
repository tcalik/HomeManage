using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence.Migrations;
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
                    new AppUser{Id = "62a3d57f-0390-4fea-b5cb-9d12c79bf876", DisplayName = "Tom", UserName="tom", Email="tom@test.com"},
                    new AppUser{DisplayName = "Lau", UserName="lau", Email="lau@test.com"},
                    new AppUser{DisplayName = "Dor", UserName="dor", Email="dor@test.com"}
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Password12");
                }
            }

            if (!context.RoomsUsers.Any())
            {
                var roomsUsers = new List<RoomUser>
                {
                    new RoomUser {AppUserId = "62a3d57f-0390-4fea-b5cb-9d12c79bf876", RoomId=new Guid("E233C81B-ADA6-4691-B44B-71463F309FCB"), IsOwner= true}
                };
                await context.RoomsUsers.AddRangeAsync(roomsUsers);
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
                    new Room {Name = "Living Room", LocationId = locationId, Id = new Guid("E233C81B-ADA6-4691-B44B-71463F309FCB")},
                    new Room {Name = "Kitchen", LocationId = locationId},
                    new Room {Name = "Kitchen", LocationId = locationId}
                };
                await context.Rooms.AddRangeAsync(rooms);
            }
            if (!context.RechangeTypes.Any())
            {
                var rechangeTypes = new List<RechangeType>
                {
                    new RechangeType {Id = new Guid("10663c84-2c2a-4994-aa56-b6c0e8ba5063"), Name = "Battery"},
                    new RechangeType {Name = "LED Bulb"}
                };
                await context.RechangeTypes.AddRangeAsync(rechangeTypes);

            }

            if (!context.RechangeObjects.Any())
            {
                Guid rechangeTypeId = new Guid("10663c84-2c2a-4994-aa56-b6c0e8ba5063");

                var rechangeObjects = new List<RechangeObject>
                {
                    new RechangeObject {Name = "AA battery", RechangeTypeId=rechangeTypeId, Id = new Guid("04E4C897-FB55-4977-A0E0-DE7C21573083")},
                    new RechangeObject {Name = "D battery", RechangeTypeId=rechangeTypeId}
                };
                await context.RechangeObjects.AddRangeAsync(rechangeObjects);

            }

            if (!context.DeviceBrands.Any())
            {
                var deviceBrands = new List<DeviceBrand>
                {
                    new DeviceBrand {Name = "Sony"},
                    new DeviceBrand {Name = "Logitech", Id = new Guid("ba047910-a8dc-4b5f-8911-54759d60982b")}
                };
                await context.DeviceBrands.AddRangeAsync(deviceBrands);
            }

            if (!context.DeviceTypes.Any())
            {
                var deviceTypes = new List<DeviceType>
                {
                    new DeviceType {Name = "Keyboard", Id = new Guid("945ddfd6-8126-4473-81bb-ac88041c27c8")},
                    new DeviceType {Name = "Controller"},
                    new DeviceType {Name = "Mouse", Id = new Guid("49d7b280-ff2c-4778-8790-9a2d191ea474")}
                };
                await context.DeviceTypes.AddRangeAsync(deviceTypes);
            }

            if (!context.DeviceModels.Any())
            {
                Guid deviceTypeIdK = new Guid("945ddfd6-8126-4473-81bb-ac88041c27c8");
                Guid deviceTypeIdM = new Guid("49d7b280-ff2c-4778-8790-9a2d191ea474");
                Guid deviceBrandId = new Guid("ba047910-a8dc-4b5f-8911-54759d60982b");
                Guid rechangeObjectId = new Guid("04E4C897-FB55-4977-A0E0-DE7C21573083");
                var deviceModels = new List<DeviceModel>
                {
                    new DeviceModel
                    {
                        Name = "K120 Wireless",
                        DeviceTypeId=deviceTypeIdK,
                        DeviceBrandId=deviceBrandId,
                        DefaultRechangeId=rechangeObjectId,
                        DefaulRechangeQuantity=2,
                        Id = new Guid("9095b2a2-3a7f-449b-a02a-804718766dc6")
                    },
                    new DeviceModel
                    {
                        Name = "M120 Wireless",
                        DeviceTypeId=deviceTypeIdM,
                        DeviceBrandId=deviceBrandId,
                        DefaultRechangeId=rechangeObjectId,
                        DefaulRechangeQuantity=1
                    },
                    new DeviceModel
                    {
                        Name = "Signature K650",
                        DeviceTypeId=deviceTypeIdK,
                        DeviceBrandId=deviceBrandId,
                        DefaultRechangeId=rechangeObjectId,
                        DefaulRechangeQuantity=2,
                        Id = new Guid("FAAC92DC-BB5A-4913-AEC0-454DAB9F2BD4")
                    }
                };
                await context.DeviceModels.AddRangeAsync(deviceModels);
            }

            if (!context.IndividualDevice.Any())
            {
                Guid deviceModelId1 = new Guid("FAAC92DC-BB5A-4913-AEC0-454DAB9F2BD4");
                Guid deviceModel2 = new Guid("9095b2a2-3a7f-449b-a02a-804718766dc6");
                Guid deviceRechangeObjectId = new Guid("04E4C897-FB55-4977-A0E0-DE7C21573083");
                Guid roomId = new Guid("E233C81B-ADA6-4691-B44B-71463F309FCB");

                var devices = new List<IndividualDevice> {
                    new IndividualDevice
                    {
                        Name= "Keyboard room",
                        DeviceModelId = deviceModelId1,
                        DeviceRechangeObjectId = deviceRechangeObjectId,
                        RoomId = roomId,
                        DeviceRechangeQuantity=2
                    },
                    new IndividualDevice
                    {
                        Name= "Random object",
                        DeviceRechangeObjectId = deviceRechangeObjectId,
                        DeviceModelId = deviceModel2,
                        RoomId = roomId,
                        DeviceRechangeQuantity=4
                    }
                };
                await context.IndividualDevice.AddRangeAsync(devices);
            }

            await context.SaveChangesAsync();
        }
    }
}
