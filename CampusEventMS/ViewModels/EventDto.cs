namespace CampusEventMS.ViewModels
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int CategoryId { get; set; }
    }
}
