using Microsoft.AspNetCore.Mvc;
using MLHere.Api.Configurations;
using MLHere.Api.Models;
using System.Collections.Generic;

namespace MLHere.Api.Controllers
{
    public class InstrumentController : BaseApiController
    {
        [HttpGet("GetInstrumentsByIoTEdgeId")]
        public IActionResult GetInstrumentsByIoTEdgeId(string ioTEdgeId)
        {

            var devices = new List<Instrument>
            {
                new Instrument
                {
                    InstrumentId = "DeviceID1",
                    Name = "Nikola Solar Energy",
                    MainCategory = "PowerSource",
                    Category = "SolarPanel",
                    BatteryPercentage = null
                },
                new Instrument
                {
                    InstrumentId = "DeviceID2",
                    Name = "Nikola Battery Energy",
                    MainCategory = "PowerSource",
                    Category = "Battery",
                    BatteryPercentage = 43
                }
            };
            return Ok(devices);
        }
    }
}