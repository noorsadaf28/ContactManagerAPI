using ContacManagerVSAPI.Models;

namespace ContacManagerVSAPI.Interfaces
{
    public interface IContactService
    {
        // Retrieve all contacts
        IEnumerable<Contact> GetAllContacts();

        // Retrieve a contact by its ID
        Contact GetContactById(int id);

        // Create a new contact with a password
        Contact CreateContact(Contact contact, string password);

        // Update an existing contact by its ID
        void UpdateContact(int id, Contact contact);

        // Delete a contact by its ID
        void DeleteContact(int id);
    }
}
