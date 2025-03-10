using AutoMapper;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace BusinessLayer.MappingProfiles
{
    public class AddressBookProfile : Profile
    {
        public AddressBookProfile()
        {
            CreateMap<ContactRequestModel, ContactEntity>().ReverseMap();

            CreateMap<ContactEntity, ContactResponseModel<ContactRequestModel>>();
        }
    }
}
