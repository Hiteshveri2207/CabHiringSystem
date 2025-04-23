using DataAccessLayer.Entity;using DTO;using Microsoft.AspNetCore.Http;using Microsoft.AspNetCore.Mvc;using Service.Implementation;using Service.Interface;namespace CabHiringSystem.Controllers{    [Route("api/Customer")]    [ApiController]    public class CustomerController : ControllerBase    {        private readonly ICustomerService _customerService;        public CustomerController(ICustomerService customerService)        {            _customerService = customerService;                   }




        [HttpPost("Add/Update")]        public async Task<ActionResult<string>> CreateOrUpdate([FromForm] CustomerDTO customerDTO)        {            if (customerDTO == null)                return BadRequest("Invalid customer data.");            var result = await _customerService.AddOrUpdate(customerDTO);            if (result == "Created")            {                return Ok("customer created successfully.");            }            if (result == "Updated")            {                return Ok("customer Updated successfully.");            }            else            {                return StatusCode(500, "Error processing customer data.");            }        }


        [HttpGet("GetBy/{Id}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetByIdAsync(Guid Id)
        {
            var customer = await _customerService.GetByIdAsync(Id);
            return Ok(customer);

        }
    }
}
