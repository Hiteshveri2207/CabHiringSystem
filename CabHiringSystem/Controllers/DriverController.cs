using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using DTO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> AddDriver([FromForm] DriverProfileDTO driverDTO)
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



        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateDriver(Guid id, [FromForm] DriverProfileDTO driver)
        {
            var success = await _driverService.UpdateDriver(id, driver);
            if (!success) return NotFound(new { message = "Driver not found" });

            return Ok(new { message = "Driver updated successfully" });
        }

      
    }
}
