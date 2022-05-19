using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingService.Models;

namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsDBContext dbContext;

        public ContactsController(ContactsDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("/")]
        public List<Contact> Get()
        {
            return dbContext.Contacts.ToList();
        }
        [HttpPost("/")]
        public Contact Post(Contact contact)
        {
            contact.ContactId = 0;
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
            return contact;
        }
        [HttpPut("/{id}")]
        public Contact Put([FromRoute] int id, [FromBody] Contact contact)
        {
            var dbContact = dbContext.Contacts.Where(m => m.ContactId == id).Single();
            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.Email = contact.Email;
            dbContact.Phone = contact.Phone;
            dbContact.Country = contact.Country;
            dbContext.Contacts.Update(dbContact);
            dbContext.SaveChanges();
            return dbContact;
        }
        [HttpDelete("/{id}")]
        public void Delete([FromRoute]int id)
        {
            var dbContact = dbContext.Contacts.Where(m => m.ContactId == id).Single();
            dbContext.Contacts.Remove(dbContact);
        }
    }
}
