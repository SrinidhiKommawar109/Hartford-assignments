using System.Security.Claims;
using CarbonCalculation.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarbonCalculation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarbonController : ControllerBase
    {
        private readonly ICarbonService _carbonService;

        public CarbonController(ICarbonService carbonService)
        {
            _carbonService = carbonService;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            var userId = GetUserId();
            var total = await _carbonService.GetTotalFootprintAsync(userId);
            return Ok(new { TotalCarbonEmission = total });
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthly()
        {
            var userId = GetUserId();
            var report = await _carbonService.GetMonthlyReportAsync(userId);
            return Ok(report);
        }
    }
}
