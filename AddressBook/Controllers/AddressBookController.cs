using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookBL _addressBookBL;

        public AddressBookController(IAddressBookBL addressBookBL)
        {
            _addressBookBL = addressBookBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponseModel<ContactRequestModel>>>> GetContacts()
        {
            return Ok(await _addressBookBL.GetContact());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ContactResponseModel<ContactRequestModel>>> GetContactById(int id)
        {
            var contact = await _addressBookBL.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]

        public async Task<ActionResult<ContactResponseModel<ContactRequestModel>>> AddContact(ContactRequestModel contactRequestModel)
        {
            var contact = await _addressBookBL.AddContact(contactRequestModel);
            return CreatedAtAction(nameof(AddContact), contact);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ContactResponseModel<ContactRequestModel>>> UpdateContact(int id, ContactRequestModel contactRequestModel)
        {
            var contact = await _addressBookBL.UpdateContact(id, contactRequestModel);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ContactResponseModel<ContactRequestModel>>> DeleteContact(int id)
        {
            var contact = await _addressBookBL.DeleteContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
    }
}
