using CampusEventMS.Data.Models;

namespace CampusEventMS.Data.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event @event);
        Task UpdateEventAsync(Event @event);
        Task DeleteEventAsync(int id);
        Task<bool> EventExistsAsync(int id);
    }
}
