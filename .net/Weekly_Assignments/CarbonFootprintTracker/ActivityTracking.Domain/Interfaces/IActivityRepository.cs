using ActivityTracking.Domain.Entities;

namespace ActivityTracking.Domain.Interfaces
{
    public interface IActivityRepository
    {
        Task AddTransportActivityAsync(TransportActivity activity);
        Task AddEnergyUsageAsync(EnergyUsage activity);
        Task AddWasteActivityAsync(WasteActivity activity);
        Task<IEnumerable<Activity>> GetActivitiesByUserIdAsync(string userId);
    }
}
