using AutoMapper;
using EmployeeProject.Common.Interface.AddressDtos;
using EmployeeProject.Common.Model;

namespace EmployeeProject.Business.MapperProfile;

public class DtoEntityMapperProfile : Profile
{
    // Creation of our mapping profile for our Address
    // Once the mapper is created we need to register in the business class 
    // it will be a static class.
    public DtoEntityMapperProfile()
    {
        CreateMap<AddressCreate, Address>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<AddressUpdate, Address>();
        CreateMap<Address, AddressGet>();
    }
}