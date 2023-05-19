using EmployeeProject.Common.Interface;
using EmployeeProject.Common.Interface.AddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.API.Controllers;

[ApiController]
[Route("Controller")]
public class AddressController : Controller
{
    private IAddressService AddressService { get; }

    public AddressController(IAddressService addressService)
    {
        AddressService = addressService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreatAddress(AddressCreate create)
    {
        var id = await AddressService.CreateAddressAsync(create);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateAsync(AddressUpdate update)
    {
        await AddressService.UpdateAddressAsync(update);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAsync(AddressDelete delete)
    {
        await AddressService.DeleteAddressAsync(delete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetAddressById(Guid id)
    {
        var address = await AddressService.GetAddressByAsync(id);
        return Ok(address);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetAddresses()
    {
       var addresses = await AddressService.GetAddressAsync();
       return Ok(addresses);
    }
}