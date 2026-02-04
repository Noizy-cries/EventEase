using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private List<Event> events = new()
        {
            new Event
            {
                Id = 1,
                Name = "Annual Tech Conference",
                Date = DateTime.Now.AddDays(30),
                Time = new TimeSpan(9, 0, 0),
                Location = "San Francisco Convention Center",
                Description = "Join us for the largest tech conference of the year featuring cutting-edge innovations.",
                AvailableSpots = 150,
                TotalSpots = 500
            },
            new Event
            {
                Id = 2,
                Name = "Startup Networking Night",
                Date = DateTime.Now.AddDays(15),
                Time = new TimeSpan(18, 30, 0),
                Location = "Downtown Business Hub",
                Description = "Connect with entrepreneurs, investors, and industry leaders.",
                AvailableSpots = 75,
                TotalSpots = 200
            },
            new Event
            {
                Id = 3,
                Name = "AI & Machine Learning Workshop",
                Date = DateTime.Now.AddDays(45),
                Time = new TimeSpan(10, 0, 0),
                Location = "Tech Institute Auditorium",
                Description = "Hands-on workshop exploring the latest AI and ML technologies.",
                AvailableSpots = 30,
                TotalSpots = 50
            }
        };

        public async Task<List<Event>> GetEventsAsync()
        {
            await Task.Delay(100);
            return events;
        }

        public async Task<Event?> GetEventAsync(int id)
        {
            await Task.Delay(50);
            return events.FirstOrDefault(e => e.Id == id);
        }

        public async Task UpdateEventSpotsAsync(int eventId, int change)
        {
            var evt = events.FirstOrDefault(e => e.Id == eventId);
            if (evt != null)
            {
                evt.AvailableSpots += change;
                await Task.Delay(50);
            }
        }
        public async Task<Event?> GetEventWithRegistrationsAsync(int eventId, List<Registration> userRegistrations)
        {
        var evt = await GetEventAsync(eventId);
    if (evt != null)
    {
        // Link user's registrations to events
        foreach (var reg in userRegistrations.Where(r => r.EventId == eventId))
        {
            reg.Event = evt;
        }
    }
    return evt;
}
    }
}