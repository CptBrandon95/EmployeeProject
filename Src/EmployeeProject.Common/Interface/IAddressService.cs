using EmployeeProject.Common.Interface.AddressDtos;

namespace EmployeeProject.Common.Interface;

public interface IAddressService
{
    Task<Guid> CreateAddressAsync(AddressCreate addressCreate);
    Task UpdateAddressAsync(AddressUpdate addressUpdate);
    Task DeleteAddressAsync(AddressDelete addressDelete);
    Task<AddressGet> GetAddressByAsync(Guid id);
    Task<List<AddressGet>> GetAddressAsync();
    
}