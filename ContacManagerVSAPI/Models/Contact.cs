namespace ContacManagerVSAPI.Models
{
    public class Contact
    {
        public int Id { get; set; } // Unique identifier for the contact
        public string FirstName { get; set; } // Contact's first name
        public string LastName { get; set; } // Contact's last name
        public string Email { get; set; } // Contact's email address
        public string PasswordHash { get; set; }  // Storing hashed passwords for security
        public string Password { get; set; } // Plain text password (used for validation)
    }
}
