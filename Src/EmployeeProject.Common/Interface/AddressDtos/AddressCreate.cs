namespace EmployeeProject.Common.Interface.AddressDtos;

/*
 * Using records for out dtos instead of classes
 * A record is a lightweight object that is used for immutable data
 * Records provide value-based equality comparison, meaning two instances of the same record with the same property values are considered equal.
 */
public record AddressCreate(string Street, string ZiP, string Cit, string Email, string? Phone);
