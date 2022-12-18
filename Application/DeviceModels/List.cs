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

namespace Application.DeviceModels
{
    public class List
    {
        public class Query : IRequest<Result<List<DeviceModelDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<DeviceModelDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<DeviceModelDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var deviceModel = await _context.DeviceModels
                    .ProjectTo<DeviceModelDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<DeviceModelDto>>.Success(deviceModel);
            }
        }
    }
}
