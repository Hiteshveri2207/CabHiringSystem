using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;

        }
        [HttpPost("Add")]
        public async Task<ActionResult<AddressDTO>> AddAsync(AddressDTO addressDTO)
        {
            await _addressService.AddAsync(addressDTO);
            return Ok(new { Message = "Address is  create", data = addressDTO });
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAllAsync()
        {
            var addresses = await _addressService.GetAllAsync();
            return Ok(new { Message = "List of the address ", Data = addresses });
        }
    }

}

