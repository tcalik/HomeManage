using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Application.Rooms;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class RoomsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            return HandleResult(await Mediator.Send(new ListRooms.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(Guid id, DataContext _context)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));

        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Room = room }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom(Guid id, Room room)
        {
            room.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Room = room }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
