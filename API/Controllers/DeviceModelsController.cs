using Application.DeviceModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DeviceModelsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetDeviceModels()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
    }
}
