using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class AddressBookBL : IAddressBookBL
    {
        private readonly IAddressBookRL _addressBookRL;

        public AddressBookBL(IAddressBookRL addressBookRL)
        {
            _addressBookRL = addressBookRL;
        }

        public async Task<IEnumerable<ContactResponseModel<ContactRequestModel>>> GetContact()
        {
            var contacts = await _addressBookRL.GetContact();
            return contacts.Select(contact => new ContactResponseModel<ContactRequestModel>
            {
                Success = "true",
                Message = "Contact List",
                Data = contact
            });
        }

        public async Task<ContactResponseModel<ContactRequestModel>> GetContactById(int id)
        {
            var contact = await _addressBookRL.GetContactById(id);
            if(contact !=null)
            {
                return new ContactResponseModel<ContactRequestModel>
                {
                    Success = "true",
                    Message = "Contact Found",
                    Data = contact
                };
            }
            
                return new ContactResponseModel<ContactRequestModel>
                {
                    Success = "false",
                    Message = "Contact Not Found",
                    Data = null
                };
            }

        public async Task<ContactResponseModel<ContactRequestModel>> AddContact(ContactRequestModel contact)
        {
            var newContact = new ContactRequestModel
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            };
            var addedContact = await _addressBookRL.AddContact(newContact);
            return new ContactResponseModel<ContactRequestModel>
            {
                Success = "true",
                Message = "Contact Added",
                Data = addedContact
            };
        }

        public async Task<ContactResponseModel<ContactRequestModel>> UpdateContact(int id, ContactRequestModel contact)
        {
            var contactUpdate = new ContactRequestModel
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            };
            var updatedContact = await _addressBookRL.UpdateContact(id, contactUpdate);
            if (updatedContact != null)
            {
                return new ContactResponseModel<ContactRequestModel>
                {
                    Success = "true",
                    Message = "Contact Updated",
                    Data = updatedContact
                };
            }
            return new ContactResponseModel<ContactRequestModel>
            {
                Success = "false",
                Message = "Contact Not Found",
                Data = null
            };
        }


        public async Task<ContactResponseModel<ContactRequestModel>> DeleteContact(int id)
        {
            var contact = await _addressBookRL.DeleteContact(id);
            if (contact != null)
            {
                return new ContactResponseModel<ContactRequestModel>
                {
                    Success = "true",
                    Message = "Contact Deleted",
                    Data = contact
                };
            }
            return new ContactResponseModel<ContactRequestModel>
            {
                Success = "false",
                Message = "Contact Not Found",
                Data = null
            };
        }

    }
}
