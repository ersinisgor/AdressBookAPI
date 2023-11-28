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


		// GET: api/<ContactsController>
		[HttpGet]
		public IEnumerable<string> AllContacts()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<ContactsController>/5
		[HttpGet("{id}")]
		public string ContactById(int id)
		{
			return "value";
		}

		// POST api/<ContactsController>
		[HttpPost]
		public void CreateContact([FromBody] string value)
		{
		}

		// PUT api/<ContactsController>/5
		[HttpPut("{id}")]
		public void UpdateContact(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ContactsController>/5
		[HttpDelete("{id}")]
		public void DeleteContact(int id)
		{
		}
	}
}
