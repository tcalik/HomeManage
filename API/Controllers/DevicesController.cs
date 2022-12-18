using Application.Devices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DevicesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
    }
}
