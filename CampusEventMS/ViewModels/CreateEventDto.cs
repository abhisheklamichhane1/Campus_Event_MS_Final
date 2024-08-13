using System.ComponentModel.DataAnnotations;

namespace CampusEventMS.ViewModels
{
    public class CreateEventDto
    {
		//Just for AutoMapping
		
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
