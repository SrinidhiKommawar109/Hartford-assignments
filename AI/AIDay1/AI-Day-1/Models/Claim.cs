using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AI_Day_1.Models
{
    public class Claim
    {
        public int Id { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [Range(1, double.MaxValue)]
        public decimal ClaimAmount { get; set; }

        public DateTime ClaimDate { get; set; }

        [JsonIgnore]
        public Policy Policy { get; set; }
    }
}
