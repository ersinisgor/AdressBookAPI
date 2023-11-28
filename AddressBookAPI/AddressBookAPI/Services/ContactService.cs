using AddressBookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Services
{
	public class ContactService
	{
		private static List<Contact> contacts = new List<Contact>()
		{
			new Contact(){Id=1, FirstName="Jack", LastName="Jackson", PhoneNumber="111-111-1111", Address="111 Main Street, Minneapolis, MN 55001"},
			new Contact(){Id=2, FirstName="John", LastName="Johnson", PhoneNumber="222-222-2222", Address="222 Main Street, Minneapolis, MN 55001"},
			new Contact(){Id=3, FirstName="Mary", LastName="Erickson", PhoneNumber="333-333-3333", Address="333 Main Street, Minneapolis, MN 55001"}
		};


		public List<Contact> GetAllContacts()
		{
			return contacts;
		}

		public Contact GetContactById(int id)
		{
			var contact = contacts.FirstOrDefault(x => x.Id == id);

			return contact;
		}

		public Contact CreateContact( Contact newContact)
		{
			var contact = new Contact();
			contact.Id = newContact.Id;
			contact.FirstName = newContact.FirstName;
			contact.LastName = newContact.LastName;
			contact.PhoneNumber = newContact.PhoneNumber;
			contact.Address = newContact.Address;
			contacts.Add(contact);

			return contact;
		}

		public Contact  UpdateContact( Contact updateContact)
		{
			var contact = contacts.FirstOrDefault(x => x.Id == updateContact.Id);
			if (contact != null)
			{
				contact.FirstName = updateContact.FirstName;
				contact.LastName = updateContact.LastName;
				contact.PhoneNumber = updateContact.PhoneNumber;
				contact.Address = updateContact.Address;

				return contact;
			}



			return null;

		}

		public bool DeleteContact(int id)
		{
			var contact = contacts.FirstOrDefault(x => x.Id == id);
			if (contact == null)
			{
				return false;
			}

			contacts.Remove(contact);
			return true;
		}
	}
}
