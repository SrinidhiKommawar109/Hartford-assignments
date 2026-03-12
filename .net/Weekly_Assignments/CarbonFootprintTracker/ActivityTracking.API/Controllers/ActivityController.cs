using System.Security.Claims;
using ActivityTracking.Application.DTOs;
using ActivityTracking.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTracking.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpPost("transport")]
        public async Task<IActionResult> AddTransport(TransportRequest request)
        {
            var userId = GetUserId();
            var updatedRequest = request with { UserId = userId };
            await _activityService.AddTransportActivityAsync(updatedRequest);
            return Ok("Transport activity added successfully.");
        }

        [HttpPost("energy")]
        public async Task<IActionResult> AddEnergy(EnergyRequest request)
        {
            var userId = GetUserId();
            var updatedRequest = request with { UserId = userId };
            await _activityService.AddEnergyUsageAsync(updatedRequest);
            return Ok("Energy usage added successfully.");
        }

        [HttpPost("waste")]
        public async Task<IActionResult> AddWaste(WasteRequest request)
        {
            var userId = GetUserId();
            var updatedRequest = request with { UserId = userId };
            await _activityService.AddWasteActivityAsync(updatedRequest);
            return Ok("Waste activity added successfully.");
        }
    }
}
