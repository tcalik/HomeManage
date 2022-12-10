using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms
{
    public class ListRooms
    {
        public class Query : IRequest<List<Room>>{}

        public class Handler : IRequestHandler<Query, List<Room>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            async Task<List<Room>> IRequestHandler<Query, List<Room>>.Handle(Query request, CancellationToken cancellationToken)
            {
                var rooms = await _context.Rooms
                    .Include(a => a.RoomUsers)
                    .ThenInclude(u => u.AppUser)
                    .ToListAsync(cancellationToken);

                return rooms;
            }
        }
    }
}
