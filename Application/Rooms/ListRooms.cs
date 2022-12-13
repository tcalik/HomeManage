using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Application.Rooms
{
    public class ListRooms
    {
        public class Query : IRequest<Result<List<RoomDto>>>{}

        public class Handler : IRequestHandler<Query, Result<List<RoomDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<RoomDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rooms = await _context.Rooms
                    .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);


                return Result<List<RoomDto>>.Success(rooms);
            }
        }
    }
}
