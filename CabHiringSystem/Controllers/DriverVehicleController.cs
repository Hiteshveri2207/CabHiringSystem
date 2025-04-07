using DataAccessLayer.Entity;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace CabHiringSystem.Controllers
{
    [Route("api/DriverVehicle")]
    [ApiController]
    public class DriverVehicleController : ControllerBase
    {
        private readonly IDriverVehicleService _driverVehicleService;

        public DriverVehicleController(IDriverVehicleService driverVehicleService)
        {
            _service = service;
        }



        [HttpPost("Add")]
        public async Task<ActionResult<DriverVehicleDTO>> AddAsync([FromBody] DriverVehicleDTO driverVehicleDTO)
        {
            if (driverVehicleDTO == null)
                return BadRequest(new { message = "Invalid data provided" });

            var result = await _service.AddAsync(driverVehicleDTO);
            if (result == null)
                return BadRequest("Unable to create DriverVehicle.");

           
            return Created("", result);  
        }
        [HttpPut("Update/{Id}")]
        public async Task <IActionResult> UpdateAsync(Guid Id, [FromBody] DriverVehicleDTO driverVehicleDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _driverVehicleService.UpdateAsync(Id, driverVehicleDTO);
            if (result == null) return NotFound();

            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var success = await _driverVehicleService.DeleteAsync(Id);
            return success ? NoContent() : NotFound(new { message = "Driver-Vehicle not found" });
        }
    }
}     
    


