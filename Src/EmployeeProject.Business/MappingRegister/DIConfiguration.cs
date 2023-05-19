using EmployeeProject.Business.MapperProfile;
using EmployeeProject.Business.Services;
using EmployeeProject.Common.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeProject.Business.MappingRegister;

public class DIConfiguration
{
    public static void RegisterServices(IServiceCollection collection)
    {
        collection.AddAutoMapper(typeof(DtoEntityMapperProfile));
        collection.AddScoped<IAddressService, AddressService>();
    }
}