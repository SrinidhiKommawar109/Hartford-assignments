using System.ComponentModel.DataAnnotations;

namespace AI_Day_1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public ICollection<Policy> Policies { get; set; }
    }

}
