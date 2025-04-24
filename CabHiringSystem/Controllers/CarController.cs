using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/Car")]
    [ApiController]
    public class CarController : ControllerBase
    {

            private readonly ICarService _carService;

            public CarController(ICarService carService)
            {
                _carService = carService;
            }

            // Add a new car
            [HttpPost("Add")]
            public async Task<ActionResult<CarDTO>> AddCar([FromBody] CarDTO carDTO)
            {
                if (carDTO == null)
                    return BadRequest("Car data is required.");

                var addedCar = await _carService.AddAsync(carDTO);
                return (addedCar);
            }

            // Get all cars
            [HttpGet("GetAll")]
            public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
            {
                var cars = await _carService.GetAllAsync();
                return Ok(cars);
            }

           
           

            // Update car details
            [HttpPut("Update/{Id}")]
            public async Task<ActionResult<CarDTO>> UpdateCar(Guid Id, [FromBody] CarDTO carDTO)
            {
                if (carDTO == null)
                    return BadRequest("Car data is required.");

                var updatedCar = await _carService.UpdateAsync(Id, carDTO);
                if (updatedCar == null)
                    return NotFound($"Car with ID {Id} not found.");

                return Ok(updatedCar);
            }

            // Delete a car
            [HttpDelete("Delete/{Id}")]
            public async Task<IActionResult> DeleteCar(Guid Id)
            {
                var result = await _carService.DeleteAsync(Id);
                if (!result)
                    return NotFound($"Car with ID {Id} not found.");

                return NoContent();
            }
    }
}

