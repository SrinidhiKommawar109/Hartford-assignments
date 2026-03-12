using CarbonCalculation.Application.DTOs;
using CarbonCalculation.Application.Interfaces;
using ActivityTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarbonCalculation.Application.Services
{
    public class CarbonService : ICarbonService
    {
        private readonly ActivityDbContext _context;

        public CarbonService(ActivityDbContext context)
        {
            _context = context;
        }

        public async Task<double> GetTotalFootprintAsync(string userId)
        {
            return await _context.Activities
                .Where(a => a.UserId == userId)
                .SumAsync(a => a.CarbonEmission);
        }

        public async Task<IEnumerable<CarbonReport>> GetMonthlyReportAsync(string userId)
        {
            var activities = await _context.Activities
                .Where(a => a.UserId == userId)
                .ToListAsync();

            return activities
                .GroupBy(a => a.Date.ToString("yyyy-MM"))
                .Select(g => new CarbonReport(
                    g.Sum(a => a.CarbonEmission),
                    g.Key))
                .OrderByDescending(r => r.Period);
        }
    }
}
