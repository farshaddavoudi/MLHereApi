using Microsoft.AspNetCore.Mvc;
using MLHere.Api.Configurations;
using MLHere.Api.Models;
using System;
using System.Collections.Generic;

namespace MLHere.Api.Controllers
{
    public class InstrumentController : BaseApiController
    {

        [HttpGet("get-instruments-by-iot-edge-id")]
        public IActionResult GetInstrumentsByIoTEdgeId(string ioTEdgeId)
        {
            // Get random devices with some rules
            /*
             * Rule 1: Random device numbers Between 2 and 17
             * Rule 2: Random device names
             * Rule 3: MainCategory = PowerSource
             * Rule 4: Random Category -> SolarPanel, Battery
             * Rule 5: Random BatteryPercentage between 0 and 100
             */

            var instruments = new List<Instrument>();

            var randomDevicesCount = new Random().Next(3, 6);

            for (int i = 0; i < randomDevicesCount; i++)
            {
                var randomCategory = new Random().Next(1, 3);
                var baseName = randomCategory == 1 ? "Solar" : "Battery";
                var randomDeviceName = $"{baseName}{i + 1}";
                int percentage = 0;
                if (randomCategory == 2)
                {
                    percentage = new Random().Next(1, 100);
                }
                var instru = new Instrument
                {
                    // InstrumentId = ???? // workaround ????
                    Name = randomDeviceName,
                    MainCategory = "PowerSource",
                    Category = randomCategory == 1 ? "SolarPanel" : "Battery",
                    BatteryPercentage = randomCategory == 1 ? (int?)null : (int)percentage
                };
                instruments.Add(instru);
            }

            return Ok(instruments);


        }
    }
}