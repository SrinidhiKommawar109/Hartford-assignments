using ActivityTracking.Application.DTOs;
using ActivityTracking.Application.Interfaces;
using ActivityTracking.Domain.Entities;
using ActivityTracking.Domain.Interfaces;

namespace ActivityTracking.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        // Emission Factors
        private const double CarFactor = 0.21;
        private const double BusFactor = 0.105;
        private const double TrainFactor = 0.041;
        private const double ElectricityFactor = 0.475;
        private const double PlasticWasteFactor = 6.0;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task AddTransportActivityAsync(TransportRequest request)
        {
            double factor = request.TransportMode.ToLower() switch
            {
                "car" => CarFactor,
                "bus" => BusFactor,
                "train" => TrainFactor,
                _ => 0
            };

            var activity = new TransportActivity
            {
                UserId = request.UserId,
                ActivityType = "Transport",
                Date = DateTime.UtcNow,
                TransportMode = request.TransportMode,
                DistanceKm = request.DistanceKm,
                CarbonEmission = request.DistanceKm * factor
            };

            await _activityRepository.AddTransportActivityAsync(activity);
        }

        public async Task AddEnergyUsageAsync(EnergyRequest request)
        {
            var activity = new EnergyUsage
            {
                UserId = request.UserId,
                ActivityType = "Energy",
                Date = DateTime.UtcNow,
                UnitsConsumed = request.UnitsConsumed,
                CarbonEmission = request.UnitsConsumed * ElectricityFactor
            };

            await _activityRepository.AddEnergyUsageAsync(activity);
        }

        public async Task AddWasteActivityAsync(WasteRequest request)
        {
            var activity = new WasteActivity
            {
                UserId = request.UserId,
                ActivityType = "Waste",
                Date = DateTime.UtcNow,
                WeightKg = request.WeightKg,
                CarbonEmission = request.WeightKg * PlasticWasteFactor
            };

            await _activityRepository.AddWasteActivityAsync(activity);
        }
    }
}
