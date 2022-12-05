using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Application.Rooms;

namespace API.Controllers
{
    public class RoomsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            return await Mediator.Send(new ListRooms.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(Guid id, DataContext _context)
        {
            return await Mediator.Send(new Details.Query { Id = id});
        }
    }
}
