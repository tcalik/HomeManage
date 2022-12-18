using Application.RechangeObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RechangeObjectController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetRechangeObjects()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
    }
}
