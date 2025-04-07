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
            [HttpPost("add")]
            public async Task<ActionResult<CarDTO>> AddCar([FromBody] CarDTO carDTO)
            {
                if (carDTO == null)
                    return BadRequest("Car data is required.");

                var addedCar = await _carService.AddAsync(carDTO);
                return (addedCar);
            }

            // Get all cars
            [HttpGet("all")]
            public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
            {
                var cars = await _carService.GetAllAsync();
                return Ok(cars);
            }

            // Get a car by ID
           

            // Update car details
            [HttpPut("update/{id}")]
            public async Task<ActionResult<CarDTO>> UpdateCar(Guid id, [FromBody] CarDTO carDTO)
            {
                if (carDTO == null)
                    return BadRequest("Car data is required.");

                var updatedCar = await _carService.UpdateAsync(id, carDTO);
                if (updatedCar == null)
                    return NotFound($"Car with ID {id} not found.");

                return Ok(updatedCar);
            }

            // Delete a car
            [HttpDelete("delete/{id}")]
            public async Task<IActionResult> DeleteCar(Guid id)
            {
                var result = await _carService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Car with ID {id} not found.");

                return NoContent();
            }
    }
}

