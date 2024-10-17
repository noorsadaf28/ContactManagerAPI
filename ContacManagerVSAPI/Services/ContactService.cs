using ContacManagerVSAPI.Interfaces;
using ContacManagerVSAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ContacManagerVSAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository; // Contact repository for data access
        private readonly PasswordHasher<Contact> _passwordHasher; // Password hasher for secure password storage

        public ContactService(IContactRepository repository)
        {
            _repository = repository; // Initialize the contact repository
            _passwordHasher = new PasswordHasher<Contact>(); // Create a password hasher instance
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _repository.GetContacts(); // Retrieve all contacts from the repository
        }

        public Contact GetContactById(int id)
        {
            return _repository.GetContactById(id); // Get a specific contact by ID
        }

        public Contact CreateContact(Contact contact, string password)
        {
            // Hash the password for secure storage
            contact.PasswordHash = _passwordHasher.HashPassword(contact, password);
            contact.Password = null; // Clear plain password to avoid storing it

            _repository.AddContact(contact); // Add the new contact to the repository
            return contact; // Return the created contact
        }

        public void UpdateContact(int id, Contact contact)
        {
            _repository.UpdateContact(contact); // Update the contact in the repository
        }

        public void DeleteContact(int id)
        {
            _repository.DeleteContact(id); // Delete the contact from the repository
        }
    }
}
