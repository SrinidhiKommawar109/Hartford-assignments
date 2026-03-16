using AI_Day_1.Data;
using AI_Day_1.DTOs.Claim;
using AI_Day_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AI_Day_1.Controllers
{
    [ApiController]
    [Route("api/claims")]
    public class ClaimsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitClaim(CreateClaimDto dto)
        {
            var policy = await _context.Policies.FindAsync(dto.PolicyId);

            if (policy == null)
                return NotFound("Policy not found");

            var claim = new Claim
            {
                PolicyId = dto.PolicyId,
                ClaimAmount = dto.ClaimAmount,
                ClaimDate = dto.ClaimDate
            };

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            return Ok(claim);
        }
    }
}
