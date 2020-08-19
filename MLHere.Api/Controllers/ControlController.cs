using Microsoft.AspNetCore.Mvc;
using MLHere.Api.Configurations;

namespace MLHere.Api.Controllers
{
    public class ControlController : BaseApiController
    {
        [HttpPost("switch-power-source")]
        public IActionResult SwitchPowerSource(string ioTEdgeId, string newPowerSource)
        {
            return NoContent();
        }

        [HttpPost("turn-appliance-on")]
        public IActionResult TurnOnAppliance(string id)
        {
            return NoContent();
        }


        [HttpPost("turn-appliance-off")]
        public IActionResult TurnOffAppliance(string id)
        {
            return NoContent();
        }
    }
}