using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SeedFluentAPI.Models
{
    [Table("Cities")]
    public class City
    { 
        [Key]
        public int CityId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        //Foreign Key
        public int StateId {  get; set; }

        [JsonIgnore]
        public State State { get; set; }
        
    }
}
