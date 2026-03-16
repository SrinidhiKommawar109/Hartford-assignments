using System.ComponentModel.DataAnnotations;

namespace AI_Day_1.DTOs.Claim
{
    public class CreateClaimDto
    {
        public int PolicyId { get; set; }

        [Range(1, double.MaxValue)]
        public decimal ClaimAmount { get; set; }

        public DateTime ClaimDate { get; set; }
    }
}
