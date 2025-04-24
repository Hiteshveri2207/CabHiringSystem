using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using DTO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entity;
using Service.Implementation;

namespace WebAPI.Controllers
{
    [Route("api/Driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DriverController(IDriverService driverService, UserManager<ApplicationUser> userManager)
        {
            _driverService = driverService;
            _userManager = userManager;
        }
        [HttpPost("Add")]
        public async Task<ActionResult<DriverProfileDTO>> AddDriver([FromForm] DriverProfileDTO driverDTO)
        {
            if (driverDTO == null)
            {
                return BadRequest(new { error = "Invalid driver data." });
            }

            try
            {
                var addedDriver = await _driverService.AddDriver(driverDTO);
                return Ok(new { message = "Driver added successfully", data = addedDriver });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<bool>> UpdateDriver(Guid Id, [FromForm] DriverProfileDTO driver)
        {
            var success = await _driverService.UpdateDriver(Id, driver);
            if (!success) return NotFound(new { message = "Driver not found" });
            return Ok(new { message = "Driver updated successfully" });
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<DriverProfileDTO>> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllAsync();
            return drivers;
        }

        [HttpGet("GetBy/{Id}")]
        public async Task<ActionResult<DriverProfileDTO>> GetByIdAsync(Guid Id)
        {
      
                var driver = await _driverService.GeyByIdAsync(Id);

                if (driver == null)
                {
                    return NotFound(new { Message = "Driver not found" });
                }

                return Ok(driver);
            


        }

    }
}
