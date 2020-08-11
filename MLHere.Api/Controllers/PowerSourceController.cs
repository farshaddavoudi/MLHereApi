using Microsoft.AspNetCore.Mvc;
using MLHere.Api.Configurations;

namespace MLHere.Api.Controllers
{
    public class PowerSourceController : BaseApiController
    {
        [HttpGet("GetPowerSource")]
        public IActionResult GetPowerSource(string ioTEdgeId)
        {
            return Ok("SolarPanel");
        }
    }
}