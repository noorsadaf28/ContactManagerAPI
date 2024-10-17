using ContacManagerVSAPI.Interfaces;
using ContacManagerVSAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContacManagerVSAPI.Controllers
{
    [Route("api/[controller]")] // Route prefix for the controller
    [ApiController] // Indicates that this class is an API controller
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service; // Dependency injection for the contact service

        // Constructor to initialize the contact service
        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // GET: api/contacts
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllContacts()); // Return all contacts
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _service.GetContactById(id); // Fetch contact by ID
            if (contact == null)
                return NotFound(); // Return 404 if contact not found
            return Ok(contact); // Return the found contact
        }

        // POST: api/contacts
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            if (string.IsNullOrEmpty(contact.Password))
            {
                return BadRequest("Password is required."); // Validate password
            }

            var createdContact = _service.CreateContact(contact, contact.Password); // Create new contact
            return CreatedAtAction(nameof(Get), new { id = createdContact.Id }, createdContact); // Return 201 with the created contact
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            _service.UpdateContact(id, contact); // Update existing contact
            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteContact(id); // Delete contact by ID
            return NoContent(); // Return 204 No Content
        }
    }
}
