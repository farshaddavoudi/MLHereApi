using Microsoft.AspNetCore.Mvc;
using MLHere.Api.Configurations;
using MLHere.Api.Models;
using System;
using System.Collections.Generic;

namespace MLHere.Api.Controllers
{
    public class EMSReportController : BaseApiController
    {
        private static readonly List<string> IoTEdgeIds = new List<string> { "Edge1", "Edge2", "Edge3", "Edge4", "Edge5", "Edge6", "Edge7", "Edge8", "Edge9", "Edge10" };

        [HttpGet("GetEMSReport")]
        public IActionResult GetEMSReport(DateTimeOffset fromDateTime = default)
        {
            fromDateTime = fromDateTime == default ? DateTimeOffset.Now : fromDateTime;
            return Ok(GetReportData(fromDateTime));
        }

        private List<EMSReportItem> GetReportData(DateTimeOffset fromDateTime)
        {
            var result = new List<EMSReportItem>();

            foreach (var ioTEdgeId in IoTEdgeIds)
            {
                result.Add(GetEachHouseReport(ioTEdgeId, fromDateTime));
            }

            return result;
        }

        private EMSReportItem GetEachHouseReport(string ioTEdgeId, DateTimeOffset fromDateTime)
        {
            /*
             * Some Information:
             * In 2018, the average annual electricity consumption for a U.S. residential utility customer was 10,972 kilowatthours (kWh),
             * an average of about 914 kWh per month, 30.46 kWh per day, 1.27 kWh per hour, 0.021 kWh per minute and 0.0018 kWh every 5 seconds
             */

            /*
             * The average price a residential customer in the United States pays for electricity is 13.31 cents per kWh.
             * equal to $ 0.1331 
             */

            var costPerKwh = (decimal)0.1331;

            var hour = fromDateTime.TimeOfDay.Hours;
            // At night [19 - 6]
            if (hour >= 19 || hour <= 6)
            {
                var baseRandomValue = new Random().Next(800, 1000);
                var baseValue = (decimal)baseRandomValue/1000000; // kWh
                var ratio = (decimal)1; // [12 - 6]
                if (hour >= 20 && hour <= 22) // اوج مصرف
                    ratio = (decimal)1.8;
                else if (hour >= 19) // [19 - 20] & [22 - 23:59]
                    ratio = (decimal)1.3;

                return new EMSReportItem
                {
                    IoTEdgeId = ioTEdgeId,
                    SolarEnergyConsumption = 0,
                    BatteryEnergyConsumption = baseValue * ratio * (decimal)0.3,
                    GridEnergyConsumption = baseValue * ratio * (decimal)0.7,
                    Cost = baseValue * ratio * costPerKwh,
                    Saving = baseValue * ratio * (decimal)0.3 * costPerKwh, // only using battery saved money
                    PeriodBegin = DateTimeOffset.Now,
                    PeriodEnd = DateTimeOffset.Now.AddSeconds(5)
                };
            }
            else
            { // At day [6 - 19]
                var baseRandomValue = new Random().Next(8, 12);
                var baseValue = (decimal)baseRandomValue/10000; // kWh
                var ratio = (decimal)1; // [6 - 12] & [15 - 17]
                if (hour >= 12 && hour <= 15) // اوج مصرف
                    ratio = (decimal)1.5;

                return new EMSReportItem
                {
                    IoTEdgeId = ioTEdgeId,
                    SolarEnergyConsumption = baseValue * ratio * (decimal)0.6,
                    BatteryEnergyConsumption = 0,
                    GridEnergyConsumption = baseValue * ratio * (decimal)0.4,
                    Cost = baseValue * ratio * costPerKwh,
                    Saving = baseValue * ratio * (decimal)0.6 * costPerKwh, // only using solar saved money
                    PeriodBegin = DateTimeOffset.Now,
                    PeriodEnd= DateTimeOffset.Now.AddSeconds(5)
                };
            }

            /* New suggestions to makes results more real:
             1- Every 5 days, make solar consumption 0 (for example because of rainy weather)
             2- Every 3 days, make solar consumption 40% (instead of 60%) and battery 10% (instead of 0) and grid to 50% (instead of 40%)
                    ((for example because of cloudy weather))
             3- Making results a little dance by a limited range
             */
        }
    }
}