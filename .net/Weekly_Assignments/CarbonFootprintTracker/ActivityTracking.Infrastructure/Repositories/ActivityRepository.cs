using ActivityTracking.Domain.Entities;
using ActivityTracking.Domain.Interfaces;
using ActivityTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracking.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivityDbContext _context;

        public ActivityRepository(ActivityDbContext context)
        {
            _context = context;
        }

        public async Task AddTransportActivityAsync(TransportActivity activity)
        {
            await _context.TransportActivities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task AddEnergyUsageAsync(EnergyUsage activity)
        {
            await _context.EnergyUsages.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task AddWasteActivityAsync(WasteActivity activity)
        {
            await _context.WasteActivities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Activity>> GetActivitiesByUserIdAsync(string userId)
        {
            return await _context.Activities
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }
    }
}
