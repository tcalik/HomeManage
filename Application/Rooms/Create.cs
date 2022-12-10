using Application.Interfaces;
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
    public class Create
    {
        public class Command : IRequest
        {
            public Room Room { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var roomUser = new RoomUser
                {
                    AppUser = user,
                    Room = request.Room,
                    IsOwner = true
                };
                request.Room.RoomUsers.Add(roomUser);

                _context.Rooms.Add(request.Room);

                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
