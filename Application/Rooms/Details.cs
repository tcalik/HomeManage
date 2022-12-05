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
    public class Details
    {
        public class Query : IRequest<Room>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Room> {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Rooms.FindAsync(request.Id);
            }
        }
    }
}
