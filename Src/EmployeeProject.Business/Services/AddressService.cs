using AutoMapper;
using EmployeeProject.Common.Interface;
using EmployeeProject.Common.Interface.AddressDtos;
using EmployeeProject.Common.Model;

namespace EmployeeProject.Business.Services;

public class AddressService : IAddressService
{
    // Mapper is private because we don't want to see from the outside
    // Not doing any validation or error handling yet.
    // Going to do it in a later stage.
    private IMapper Mapper { get; }
    public IGenericRepository<Address> AddresRepository { get; }

    public AddressService(IMapper mapper,IGenericRepository<Address>addresRepository)
    {
        Mapper = mapper;
        AddresRepository = addresRepository;
    }
    
    // First we aree going to create our entity by using the mapper
    // This method creates a new address entity by using AutoMapper 
    // to map the properties provided "addressCreate" object.
    public async Task<Guid> CreateAddressAsync(AddressCreate addressCreate)
    {
        var entity = Mapper.Map<Address>(addressCreate);
        await AddresRepository.InsertAsync(entity);
        await AddresRepository.SaveChangesAsync();
        return entity.Id;
    }

    public Task UpdateAddressAsync(AddressUpdate addressUpdate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAddressAsync(AddressDelete addressDelete)
    {
        throw new NotImplementedException();
    }

    public Task<AddressGet> GetAddressByAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AddressGet>> GetAddressAsync()
    {
        throw new NotImplementedException();
    }
}