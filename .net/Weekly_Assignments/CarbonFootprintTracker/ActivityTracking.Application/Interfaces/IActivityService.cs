using ActivityTracking.Application.DTOs;

namespace ActivityTracking.Application.Interfaces
{
    public interface IActivityService
    {
        Task AddTransportActivityAsync(TransportRequest request);
        Task AddEnergyUsageAsync(EnergyRequest request);
        Task AddWasteActivityAsync(WasteRequest request);
    }
}
