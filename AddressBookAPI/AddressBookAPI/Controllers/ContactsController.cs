using AddressBookAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBookAPI.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private static List<Contact> contacts = new List<Contact>()
		{
			new Contact(){Id=1, FirstName="Jack", LastName="Jackson", PhoneNumber="111-111-1111", Address="111 Main Street, Minneapolis, MN 55001"},
			new Contact(){Id=2, FirstName="John", LastName="Johnson", PhoneNumber="222-222-2222", Address="222 Main Street, Minneapolis, MN 55001"},
			new Contact(){Id=3, FirstName="Mary", LastName="Erickson", PhoneNumber="333-333-3333", Address="333 Main Street, Minneapolis, MN 55001"}
		};


		[HttpGet]
		public IActionResult AllContacts()
		{
			return Ok(contacts);
		}

		[HttpGet("{id}")]
		public IActionResult ContactById(int id)
		{
			var contact = contacts.FirstOrDefault(x => x.Id == id);
			if (contact == null)
			{
				return BadRequest("Can not find this contact");
			}
			return Ok(contact);
		}

		[HttpPost]
		public IActionResult CreateContact([FromBody] Contact newContact)
		{
			var contact = new Contact();
			contact.Id = newContact.Id;
			contact.FirstName = newContact.FirstName;
			contact.LastName = newContact.LastName;
			contact.PhoneNumber = newContact.PhoneNumber;
			contact.Address = newContact.Address;
			contacts.Add(contact);

			return Ok(contact);
		}

		[HttpPut]
		public IActionResult UpdateContact([FromBody] Contact updateContact)
		{
			var contact = contacts.FirstOrDefault(x => x.Id == updateContact.Id);
			if (contact == null)
			{
				return BadRequest("Can not find this contact to update");
			}

			contact.FirstName = updateContact.FirstName;
			contact.LastName = updateContact.LastName;
			contact.PhoneNumber = updateContact.PhoneNumber;
			contact.Address = updateContact.Address;

			return Ok(contact);

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var contact = contacts.FirstOrDefault(x => x.Id == id);
			if (contact == null)
			{
				return BadRequest("Can not find this contact to delete");
			}

			contacts.Remove(contact);
			return Ok("The contact has been deleted");
		}
	}
}
