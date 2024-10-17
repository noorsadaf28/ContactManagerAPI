using ContacManagerVSAPI.Interfaces;
using ContacManagerVSAPI.Models;
using System.Text.Json;

namespace ContacManagerVSAPI.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _dataFile = "contacts.json"; // Path to the JSON data file

        // Get all contacts from the data file
        public IEnumerable<Contact> GetContacts()
        {
            if (!File.Exists(_dataFile)) // Check if the data file exists
                return new List<Contact>(); // Return an empty list if not found

            var json = File.ReadAllText(_dataFile); // Read the content of the data file
            return JsonSerializer.Deserialize<List<Contact>>(json); // Deserialize JSON to List<Contact>
        }

        // Get a contact by its ID
        public Contact GetContactById(int id)
        {
            return GetContacts().FirstOrDefault(c => c.Id == id); // Return the first matching contact
        }

        // Add a new contact
        public void AddContact(Contact contact)
        {
            var contacts = GetContacts().ToList(); // Get current contacts
            contact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1; // Assign a new ID
            contacts.Add(contact); // Add the new contact
            SaveContacts(contacts); // Save the updated contact list
        }

        // Update an existing contact
        public void UpdateContact(Contact contact)
        {
            var contacts = GetContacts().ToList(); // Get current contacts
            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id); // Find the contact to update
            if (existingContact != null) // If found, update its details
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                SaveContacts(contacts); // Save the updated contact list
            }
        }

        // Delete a contact by ID
        public void DeleteContact(int id)
        {
            var contacts = GetContacts().ToList(); // Get current contacts
            var contact = contacts.FirstOrDefault(c => c.Id == id); // Find the contact to delete
            if (contact != null) // If found, remove it from the list
            {
                contacts.Remove(contact);
                SaveContacts(contacts); // Save the updated contact list
            }
        }

        // Save the contacts list to the data file
        private void SaveContacts(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts); // Serialize the contact list to JSON
            File.WriteAllText(_dataFile, json); // Write the JSON to the data file
        }
    }
}
