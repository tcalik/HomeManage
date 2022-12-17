using Domain;
using FluentValidation;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LocationId).NotEmpty();
        }
    }
}
