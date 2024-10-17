# Contact Manager API

## Overview
The Contact Manager API is a RESTful web service that allows users to manage contact information effectively. This API facilitates creating, reading, updating, and deleting (CRUD) operations for contact data, ensuring secure handling of sensitive information like passwords. Built on **ASP.NET Core**, this project emphasizes modularity, scalability, and security.

## Features
- **CRUD Operations**: Perform Create, Read, Update, and Delete operations on contact data.
- **Password Hashing**: Securely store passwords using hashing to prevent unauthorized access.
- **RESTful API Design**: Follow standard HTTP methods for seamless integration and usability.
- **Data Persistence**: Store contact information in a JSON file for simplicity and ease of access.
- **Input Validation**: Validate input data to ensure integrity and correctness.

## Framework Versions
- **Framework**: ASP.NET Core 7.0

## .NET Versions
- **.NET SDK**: 6.0.100 or later

## Libraries and Their Versions
- **Microsoft.AspNetCore.Mvc**: 6.0.0
- **Microsoft.AspNetCore.Identity**: 6.0.0
- **System.Text.Json**: 6.0.0

## API Endpoints

| Method | Endpoint               | Description                          |
|--------|------------------------|--------------------------------------|
| GET    | /api/contacts          | Retrieve a list of all contacts.    |
| GET    | /api/contacts/{id}     | Retrieve a specific contact by ID.   |
| POST   | /api/contacts          | Create a new contact.               |
| PUT    | /api/contacts/{id}     | Update an existing contact by ID.   |
| DELETE | /api/contacts/{id}     | Delete a contact by ID.             |

## Interfaces

### IContactService
Defines methods for managing contacts:
- `IEnumerable<Contact> GetAllContacts()`
- `Contact GetContactById(int id)`
- `Contact CreateContact(Contact contact, string password)`
- `void UpdateContact(int id, Contact contact)`
- `void DeleteContact(int id)`

### IContactRepository
Defines methods for data access operations on contacts:
- `IEnumerable<Contact> GetContacts()`
- `Contact GetContactById(int id)`
- `void AddContact(Contact contact)`
- `void UpdateContact(Contact contact)`
- `void DeleteContact(int id)`

## Services
### ContactService
Implements `IContactService` for handling business logic related to contacts. It uses `IContactRepository` to access and manipulate contact data.

## Data Details

### Contact Model
The Contact class represents a contact entity with the following properties:
- **int Id**: Unique identifier for the contact.
- **string FirstName**: First name of the contact.
- **string LastName**: Last name of the contact.
- **string Email**: Email address of the contact.
- **string PasswordHash**: Hashed password for secure storage.
- **string Password**: Plain password (cleared after hashing).

### Data Storage
Contact data is stored in a JSON file (`contacts.json`). This simple approach allows for quick access and manipulation without requiring a database server.

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/noorsadaf28/ContactManagerAPI.git

2. Open the Project:
	You may need to open the solution file (.sln) if it doesn't open automatically.
	Once cloned, navigate to the project directory within Visual Studio.

3. Restore NuGet Packages:
	Right-click on the solution in the Solution Explorer.
	Select Restore NuGet Packages. This will download and install the required packages for the project.

4. Build the Application:
	Click on Build > Build Solution in the menu or press Ctrl + Shift + B to build the application.

5. Run the Application:
	Set the project as the startup project by right-clicking on the project in the Solution Explorer and selecting Set as Startup Project.
	Press F5 or click on the Start button to run the application. This will launch the API, and you can view it in your default web browser.

6. Access the API:
	Open a web browser or a tool like Postman to test the API endpoints using the URLs provided in the API documentation.
