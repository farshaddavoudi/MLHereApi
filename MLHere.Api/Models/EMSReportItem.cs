namespace MLHere.Api.Models
{
    public class EMSReportItem
    {
        public string IoTEdgeId { get; set; }

        public decimal BatteryEnergyConsumption { get; set; }

        public decimal SolarEnergyConsumption { get; set; }

        public decimal GridEnergyConsumption { get; set; }

        public decimal Cost { get; set; }

        public decimal Saving { get; set; }

    }
}