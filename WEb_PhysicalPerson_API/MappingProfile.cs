using AutoMapper;
using WEb_PhysicalPerson_API.DTOs;
using WEb_PhysicalPerson_API.DTOs.ConnectedPersonDTO;
using WEb_PhysicalPerson_API.DTOs.PersonDTO;
using WEb_PhysicalPerson_API.DTOs.PhoneNumberDTO;
using WEb_PhysicalPerson_API.Models;

namespace WEb_PhysicalPerson_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, GetPersonDTO>();
            CreateMap<Person, AddPersonDTO>();
            CreateMap<Person, UpdatePersonDTO>();

            CreateMap<AddPersonDTO, Person>();
            CreateMap<UpdatePersonDTO, Person>();
            //---ConnectedPerson
            CreateMap<ConnectedPersonDTO, ConnectedPerson>();
            CreateMap<ConnectedPersonDTO, ConnectedPerson>().ReverseMap();
            //---Phone
            CreateMap<Phone, GetPhoneDTO>();
            CreateMap<Phone, AddPhoneDTO>();
            CreateMap<Phone, UpdatePhoneDTO>();

            CreateMap<AddPhoneDTO,Phone>();
            CreateMap<UpdatePhoneDTO, Phone>();

        }
    }
}
