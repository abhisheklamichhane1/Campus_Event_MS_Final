using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusEventMS.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Location field is required.")]
        [StringLength(255, ErrorMessage = "The Location field cannot exceed 255 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }

        // Navigation property
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
