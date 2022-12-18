using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RechangeObjects
{
    public class List
    {
        public class Query : IRequest<Result<List<RechangeObjectDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<RechangeObjectDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<RechangeObjectDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rechangeObjects = await _context.RechangeObjects
                    .ProjectTo<RechangeObjectDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<RechangeObjectDto>>.Success(rechangeObjects);
            }
        }
    }
}
