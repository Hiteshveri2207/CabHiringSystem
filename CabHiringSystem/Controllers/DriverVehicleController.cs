using DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace CabHiringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverVehicleController : ControllerBase
    {
        private readonly IDriverVehicleService _service;
        private object GetById;

        public DriverVehicleController(IDriverVehicleService service)
        {
            _service = service;
        }



        [HttpPost("Add")]
        public async Task<ActionResult<DriverVehicleDTO>> Add([FromBody] DriverVehicleDTO driverVehicleDTO)
        {
            if (driverVehicleDTO == null)
                return BadRequest("Invalid data.");

            var result = await _service.AddAsync(driverVehicleDTO);
            if (result == null)
                return BadRequest("Unable to create DriverVehicle.");

           
            return Created("", result);  
        }


        [HttpPut("Put/{id}")]
        public async Task<ActionResult<DriverVehicleDTO>> Update(Guid id, [FromBody] DriverVehicleDTO driverVehicleDTO)
        {
            if (driverVehicleDTO == null)
                return BadRequest("Invalid data.");

            var result = await _service.UpdateAsync(id, driverVehicleDTO);
            if (result == null) return NotFound("DriverVehicle not found.");

            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("DriverVehicle not found.");

            return NoContent();
        }
    }
}
