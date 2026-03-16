using AI_Day_1.Data;
using AI_Day_1.DTOs.Policy;
using AI_Day_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI_Day_1.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class PoliciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolicy(CreatePolicyDto dto)
        {
            var customer = await _context.Customers.FindAsync(dto.CustomerId);

            if (customer == null)
                return NotFound("Customer not found");

            var policy = new Policy
            {
                PolicyType = dto.PolicyType,
                PremiumAmount = dto.PremiumAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CustomerId = dto.CustomerId
            };

            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();

            return Ok(policy);
        }
        [HttpGet("/api/customers/{customerId}/policies")]
        public async Task<IActionResult> GetPoliciesByCustomer(int customerId)
        {
            var policies = await _context.Policies
                .Where(p => p.CustomerId == customerId)
                .ToListAsync();

            return Ok(policies);
        }
        [HttpPut("{policyId}")]
        public async Task<IActionResult> UpdatePolicy(int policyId, UpdatePolicyDto dto)
        {
            var policy = await _context.Policies.FindAsync(policyId);

            if (policy == null)
                return NotFound();

            policy.PolicyType = dto.PolicyType;
            policy.PremiumAmount = dto.PremiumAmount;
            policy.StartDate = dto.StartDate;
            policy.EndDate = dto.EndDate;

            await _context.SaveChangesAsync();

            return Ok(policy);
        }
    }
}
 