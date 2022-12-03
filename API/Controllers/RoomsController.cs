﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class RoomsController : BaseApiController
    {
        private readonly DataContext _context;

        public RoomsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public DataContext Get_context()
        {
            return _context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(Guid Id, DataContext _context)
        {
            return await _context.Rooms.FindAsync(Id);
        }
    }
}
