using EventEase.Models;

namespace EventEase.Services
{
    public class AppState
    {
        public User? CurrentUser { get; private set; }
        public UserSession CurrentSession { get; private set; } = new();
        public event Action? OnChange;
        
        // Login/Signup
        public void Login(string name, string email)
        {
            CurrentUser = new User
            {
                Name = name,
                Email = email
            };
            
            CurrentSession.LastActivity = DateTime.Now;
            NotifyStateChanged();
        }
        
        public void Logout()
        {
            CurrentUser = null;
            CurrentSession = new UserSession();
            NotifyStateChanged();
        }
        
        public bool IsLoggedIn => CurrentUser != null;
        
        // Registration management
        public void AddRegistration(Registration registration)
        {
            if (CurrentUser != null)
            {
                registration.UserId = CurrentUser.Id;
                CurrentUser.Registrations.Add(registration);
                CurrentSession.LastActivity = DateTime.Now;
                NotifyStateChanged();
            }
        }
        
        public List<Registration> GetUserRegistrations()
        {
            return CurrentUser?.Registrations ?? new List<Registration>();
        }
        
        public int GetUserRegistrationCount()
        {
            return CurrentUser?.Registrations.Count ?? 0;
        }
        
        // For backward compatibility
        public int GetTotalRegistrations()
        {
            return GetUserRegistrationCount();
        }
        
        public List<Registration> GetRegistrations()
        {
            return GetUserRegistrations();
        }
        
        public void ClearSession()
        {
            CurrentUser = null;
            CurrentSession = new UserSession();
            NotifyStateChanged();
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}