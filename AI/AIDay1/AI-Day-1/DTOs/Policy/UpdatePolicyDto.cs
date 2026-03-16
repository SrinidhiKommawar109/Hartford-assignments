using System.ComponentModel.DataAnnotations;

namespace AI_Day_1.DTOs.Policy
{
    public class UpdatePolicyDto
    {
        public string PolicyType { get; set; }

        [Range(1, double.MaxValue)]
        public decimal PremiumAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
