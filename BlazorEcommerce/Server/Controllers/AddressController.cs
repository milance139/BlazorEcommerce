using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ServiceResponse<Address>> GetAddress()
        {
            var result = await _addressService.GetAddress();
            return result;
        }

        [HttpPost]
        public async Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address)
        {
            var result = await _addressService.AddOrUpdateAddress(address);
            return result;
        }
    }
}
