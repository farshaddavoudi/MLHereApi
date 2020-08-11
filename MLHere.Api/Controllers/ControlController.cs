using Microsoft.AspNetCore.Mvc;
using MLHere.Api.Configurations;

namespace MLHere.Api.Controllers
{
    public class ControlController : BaseApiController
    {
        [HttpPost("SwitchPowerSource")]
        public IActionResult SwitchPowerSource(string ioTEdgeId, string newPowerSource)
        {
            return NoContent();
        }

        [HttpPost("TurnApplianceOn")]
        public IActionResult TurnOnAppliance(string id)
        {
            return NoContent();
        }


        [HttpPost("TurnApplianceOff")]
        public IActionResult TurnOffAppliance(string id)
        {
            return NoContent();
        }
    }
}