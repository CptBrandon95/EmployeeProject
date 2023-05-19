namespace EmployeeProject.Common.Interface.AddressDtos;

public record AddressUpdate(Guid Id, string Street, string Zip, string City, string Email, string? Phone);
