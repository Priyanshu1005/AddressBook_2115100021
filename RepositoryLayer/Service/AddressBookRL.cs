using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class AddressBookRL : IAddressBookRL
    {
        private readonly AddressBookDbContext _context;

        public AddressBookRL(AddressBookDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// this function is used to return all the contacts from the database
        /// </summary>
        /// <returns></returns>
        
        public async Task<IEnumerable<ContactRequestModel>> GetContact()
        {
            return _context.Contacts.Select(contact => new ContactRequestModel
            {
                
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            });
        }

        /// <summary>
        /// this function is used to display the information by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<ContactRequestModel> GetContactById(int id)
        {
            var contact = _context.Contacts.Find(id);
            return new ContactRequestModel
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            };
        }

        /// <summary>
        /// this function is used to add contact to the database
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>

        public async Task<ContactRequestModel> AddContact(ContactRequestModel contact)
        {
            var newContact = new ContactEntity
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            };
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
            return contact;
        }

        /// <summary>
        /// this function is used to update the contact information
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>

        public async Task<ContactRequestModel> UpdateContact(int id, ContactRequestModel contact)
        {
            var contactUpdate = _context.Contacts.Find(id);
            if (contactUpdate != null)
            {
                contactUpdate.Name = contact.Name;
                contactUpdate.Email = contact.Email;
                contactUpdate.Phone = contact.Phone;
                _context.SaveChanges();
            }
            return contact;
        }
        /// <summary>
        /// this function is used to delete the contact information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<ContactRequestModel> DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return new ContactRequestModel
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
            };
        }
    }
}
