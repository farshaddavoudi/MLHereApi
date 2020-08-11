namespace MLHere.Api.Models
{
    public class Instrument
    {
        public string InstrumentId { get; set; }

        public string Name { get; set; }

        public string MainCategory { get; set; }

        public string Category { get; set; }

        public decimal? BatteryPercentage { get; set; }
    }
}