using DataAccessLayer.Entity;using DTO;using Microsoft.AspNetCore.Http;using Microsoft.AspNetCore.Mvc;using Service.Implementation;using Service.Interface;namespace CabHiringSystem.Controllers{    [Route("api/Customer")]    [ApiController]    public class CustomerController : ControllerBase    {        private readonly ICustomerService _CustomerService;        public CustomerController(ICustomerService CustomerService)        {            _CustomerService = CustomerService;                   }




        [HttpPost("Add/Update")]        public async Task<IActionResult> CreateOrUpdate([FromForm] CustomerDTO customerDTO)        {            if (customerDTO == null)                return BadRequest("Invalid customer data.");            var result = await _CustomerService.AddOrUpdate(customerDTO);            if (result == "Created")            {                return Ok("customer created successfully.");            }            if (result == "Updated")            {                return Ok("customer Updated successfully.");            }            else            {                return StatusCode(500, "Error processing customer data.");            }        }


        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetCustomerProfileByIdAsync(Guid Id)
        {
            var customers = await _CustomerService.GetCustomerProfileByIdAsync(Id);
            if(customers == null )
            {
                return NotFound("Customer not Found");
            }
            return Ok(customers);
        }
    }
}
