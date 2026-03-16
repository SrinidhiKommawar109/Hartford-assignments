using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AI_Day_1.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        public string PolicyType { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal PremiumAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

        public ICollection<Claim> Claims { get; set; }
    }
}
