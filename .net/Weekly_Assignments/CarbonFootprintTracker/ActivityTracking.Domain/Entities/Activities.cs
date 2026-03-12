namespace ActivityTracking.Domain.Entities
{
    public abstract class Activity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string ActivityType { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public double CarbonEmission { get; set; }
    }

    public class TransportActivity : Activity
    {
        public string TransportMode { get; set; } = string.Empty;
        public double DistanceKm { get; set; }
    }

    public class EnergyUsage : Activity
    {
        public double UnitsConsumed { get; set; }
    }

    public class WasteActivity : Activity
    {
        public double WeightKg { get; set; }
    }
}
