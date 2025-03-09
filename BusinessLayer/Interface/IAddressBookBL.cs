using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;

namespace BusinessLayer.Interface
{
    public interface IAddressBookBL
    {
        Task<IEnumerable<ContactResponseModel<ContactRequestModel>>> GetContact();
        Task<ContactResponseModel<ContactRequestModel>> GetContactById(int id);
        Task<ContactResponseModel<ContactRequestModel>> AddContact(ContactRequestModel contact);
        Task<ContactResponseModel<ContactRequestModel>> UpdateContact(int id, ContactRequestModel contact);
        Task<ContactResponseModel<ContactRequestModel>> DeleteContact(int id);
    }
}
