using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Room Room { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var room = await _context.Rooms.FindAsync(request.Room.Id);

                _mapper.Map(request.Room, room);

                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }

    }
}
