using System.ComponentModel.DataAnnotations;

namespace CampusEventMS.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Location field is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The CategoryId field is required.")]
        public int CategoryId { get; set; }
    }
}
