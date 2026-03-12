using CarbonCalculation.Application.DTOs;

namespace CarbonCalculation.Application.Interfaces
{
    public interface ICarbonService
    {
        Task<double> GetTotalFootprintAsync(string userId);
        Task<IEnumerable<CarbonReport>> GetMonthlyReportAsync(string userId);
    }
}
