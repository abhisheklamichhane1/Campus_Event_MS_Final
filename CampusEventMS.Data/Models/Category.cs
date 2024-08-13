using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CampusEventMS.Data.Models
{
    public class Category
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }


        // Navigation property
        //[JsonIgnore]
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
 
