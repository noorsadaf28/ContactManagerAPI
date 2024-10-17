using ContacManagerVSAPI.Models;

namespace ContacManagerVSAPI.Interfaces
{
    public interface IContactRepository
    {
        // Retrieve all contacts
        IEnumerable<Contact> GetContacts();

        // Retrieve a contact by its ID
        Contact GetContactById(int id);

        // Add a new contact
        void AddContact(Contact contact);

        // Update an existing contact
        void UpdateContact(Contact contact);

        // Delete a contact by its ID
        void DeleteContact(int id);
    }
}
