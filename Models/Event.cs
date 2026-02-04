namespace EventEase.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableSpots { get; set; }
        public int TotalSpots { get; set; }
    }

    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Registration> Registrations { get; set; } = new();
    }

    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public Event? Event { get; set; }
    }

    public class UserSession
    {
        public string SessionId { get; set; } = Guid.NewGuid().ToString();
        public DateTime LastActivity { get; set; } = DateTime.Now;
        public List<Registration> Registrations { get; set; } = new();
    }
}