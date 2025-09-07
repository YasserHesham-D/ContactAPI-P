using ContactsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ContactsApi.Data;
using Microsoft.EntityFrameworkCore;
namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(AppDbContext context) : ControllerBase
    {
    
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contact = await context.contacts.ToListAsync();
            return Ok(contact);
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllGGG()
        {

            return Ok("GGG");
        }

        [HttpPost]
        public async Task<IActionResult> PostContactAsync(ContactDto contactDto)
        {

           var contact = new Contact 
           {
                Id=Guid.NewGuid()
               ,Name=contactDto.Name
               ,Email=contactDto.Email
               ,Phone=contactDto.Phone
               ,Favourite=contactDto.Favourite
           };
           await context.contacts.AddAsync(contact);
           await context.SaveChangesAsync();
           
            return Ok(contact);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContactAsync(Guid id)
        {
            var contact = await context.contacts.FindAsync(id);
            if (contact is not null)
            {
                context.contacts.Remove(contact);
                await context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
