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
            _driverVehicleService = driverVehicleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<DriverVehicleResponseDTO>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            var (vehicle, totalCount) = await _driverVehicleService.GetAllAsync(pageNumber, pageSize);
            return Ok(new
            {
                TotalCount = totalCount,
                Vehicle = vehicle
            });
        }
          
        [HttpGet("GetBy/{Id}")]
        public async Task<ActionResult<DriverVehicleResponseDTO>> GetByIdAsync(Guid Id)
        {
            var result = await _driverVehicleService.GetByIdAsync(Id);
            return result == null ? NotFound(new { message = "Driver-Vehicle record not found" }) : Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<DriverVehicleDTO>> AddAsync([FromBody] DriverVehicleDTO driverVehicleDTO)
        {
            if (driverVehicleDTO == null)
                return BadRequest(new { message = "Invalid data provided" });

            var result = await _driverVehicleService.AddAsync(driverVehicleDTO);
            return Ok(result); 
        }
        [HttpPut("Update/{Id}")]
        public async Task <IActionResult> UpdateAsync(Guid Id, [FromBody] DriverVehicleDTO driverVehicleDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _driverVehicleService.UpdateAsync(Id, driverVehicleDTO);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid Id)
        {
            var success = await _driverVehicleService.DeleteAsync(Id);
            return success ? NoContent() : NotFound(new { message = "Driver-Vehicle not found" });
        }
    }
}
