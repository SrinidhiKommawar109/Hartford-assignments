namespace ActivityTracking.Application.DTOs
{
    public record TransportRequest(string UserId, string TransportMode, double DistanceKm);
    public record EnergyRequest(string UserId, double UnitsConsumed);
    public record WasteRequest(string UserId, double WeightKg);
}
