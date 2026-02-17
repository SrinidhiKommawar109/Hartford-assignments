using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace SeedFluentAPI.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(20)]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(20)]
        public string CountryCode { get; set; }

        //This will create the County master table and have one-to-many relationships with the State table. That is, one country can have multiple states.
        [JsonIgnore]
        public ICollection<State> States { get; set; }
    }
}
