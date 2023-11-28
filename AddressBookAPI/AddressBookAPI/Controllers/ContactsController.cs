using AddressBookAPI.Models;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBookAPI.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{

		[HttpGet]
		public IActionResult AllContacts()
		{
			var service = new ContactService();
			return Ok(service.GetAllContacts());
		}

		[HttpGet("{id}")]
		public IActionResult ContactById(int id)
		{
			var service = new ContactService();
			var contact = service.GetContactById(id);
			if (contact == null)
			{
				return BadRequest("Can not find this contact");
			}
			return Ok(contact);
		}

		[HttpPost]
		public IActionResult CreateContact([FromBody] Contact newContact)
		{
			var service = new ContactService();

			var contact = service.CreateContact(newContact);
			if (contact == null)
			{
				return BadRequest("Can not find this contact to update");
			}


			return Ok(contact);
		}

		[HttpPut]
		public IActionResult UpdateContact([FromBody] Contact updateContact)
		{
			var service = new ContactService();

			var contact = service.UpdateContact(updateContact);
			if (contact == null)
			{
				return BadRequest("Can not find this contact to update");
			}

			return Ok(contact);

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var service = new ContactService();

			var result = service.DeleteContact(id);
			if (result == false)
			{
				return BadRequest("Can not find this contact to delete");
			}

			
			return Ok("The contact has been deleted");
		}
	}
}
