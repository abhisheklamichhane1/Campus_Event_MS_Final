using CampusEventMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusEventMS.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor to initialize the repository with the application context
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all events from the database, including related category data
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.Include(e => e.Category).ToListAsync();
        }

        // Retrieve an event by its ID, including related category data
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        // Add a new event to the database
        public async Task AddEventAsync(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
        }

        // Update an existing event in the database
        public async Task UpdateEventAsync(Event @event)
        {
            _context.Events.Update(@event);
            await _context.SaveChangesAsync();
        }

        // Delete an event by its ID
        public async Task DeleteEventAsync(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
                await _context.SaveChangesAsync();
            }
        }

        // Check if an event exists by its ID
        public async Task<bool> EventExistsAsync(int id)
        {
            return await _context.Events.AnyAsync(e => e.Id == id);
        }
    }
}
