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

namespace Application.Devices
{
    public class List
    {
        public class Query : IRequest<Result<List<IndividualDeviceDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<IndividualDeviceDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<IndividualDeviceDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var individualDevices = await _context.IndividualDevice
                    .ProjectTo<IndividualDeviceDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<IndividualDeviceDto>>.Success(individualDevices);
            }
        }
    }
}
