using CampusEventMS.Data.Models;
using CampusEventMS.Data.Repositories;
using CampusEventMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusEventMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        // Constructor to initialize the event repository through dependency injection
        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/events
        // This endpoint retrieves all events from the repository
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return Ok(events); // Returns a 200 OK response with the list of events
        }

        // POST: api/events
        // This endpoint creates a new event
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto createEventDto)
        {
            // Check if the incoming model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request response if the model state is invalid
            }

            // Validate if the provided CategoryId exists
            var category = await _eventRepository.GetEventByIdAsync(createEventDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid CategoryId"); // Return a 400 Bad Request response if the CategoryId is invalid
            }

            // Create a new event entity based on the incoming DTO
            var @event = new Event
            {
                Name = createEventDto.Name,
                Date = createEventDto.Date,
                Location = createEventDto.Location,
                CategoryId = createEventDto.CategoryId
            };

            // Save the new event to the repository
            await _eventRepository.AddEventAsync(@event);

            // Return a 201 Created response, with the newly created event details
            return CreatedAtAction(nameof(GetEventById), new { id = @event.Id }, @event);
        }

        // GET: api/events/{id}
        // This endpoint retrieves a specific event by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var @event = await _eventRepository.GetEventByIdAsync(id);

            // Check if the event exists
            if (@event == null)
            {
                return NotFound(); // Return a 404 Not Found response if the event does not exist
            }

            return Ok(@event); // Return a 200 OK response with the event details
        }

        // PUT: api/events/{id}
        // This endpoint updates an existing event
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] CreateEventDto updateEventDto)
        {
            // Check if the event ID in the route matches the one in the DTO
            if (id != updateEventDto.Id)
            {
                return BadRequest("Event ID mismatch"); // Return a 400 Bad Request response if there is a mismatch
            }

            // Check if the incoming model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request response if the model state is invalid
            }

            // Retrieve the existing event from the repository
            var @event = await _eventRepository.GetEventByIdAsync(id);
            if (@event == null)
            {
                return NotFound(); // Return a 404 Not Found response if the event does not exist
            }

            // Update the event properties with the new values from the DTO
            @event.Name = updateEventDto.Name;
            @event.Date = updateEventDto.Date;
            @event.Location = updateEventDto.Location;
            @event.CategoryId = updateEventDto.CategoryId;

            // Validate if the provided CategoryId exists
            var category = await _eventRepository.GetEventByIdAsync(updateEventDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Invalid CategoryId"); 
            }


            try
            {
                // Save the updated event to the repository
                await _eventRepository.UpdateEventAsync(@event);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Check if the event still exists after the update attempt
                if (!await _eventRepository.EventExistsAsync(id))
                {
                    return NotFound(); 
                }
                throw; 
            }

            // Return a 204 No Content response to indicate the update was successful
            return NoContent();
        }


        // DELETE: api/events/{id}
        // This endpoint deletes an event by its ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            // Retrieve the event to be deleted from the repository
            var @event = await _eventRepository.GetEventByIdAsync(id);
            if (@event == null)
            {
                return NotFound(); 
            }

            // Delete the event from the repository
            await _eventRepository.DeleteEventAsync(id);

            // Return a 204 No Content response to indicate the deletion was successful
            return NoContent();
        }
    }
}
