using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeedFluentAPI.Models
{
    
        [Table("States")]
        public class State
        {
            [Key]
            public int StateId { get; set; }

            [Required]
            [MaxLength(20)]
            public string StateName { get; set; }

            public int CountryId { get; set; }
        //Foreign Key

        //Navigation Property - Same as Refernces in SQL server
        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore]
            public ICollection<City> cities { get; set; }
        }
    }

