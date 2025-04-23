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

            [HttpPost("Add")]
            public async Task<ActionResult<CarDTO>> AddCar([FromBody] CarDTO carDTO)
            {
                if (carDTO == null)
                    return BadRequest("Car data is required.");

                var addedCar = await _carService.AddAsync(carDTO);
                return (addedCar);
            }

            [HttpGet("GetAll")]
            public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
            {
                var cars = await _carService.GetAllAsync();
                return Ok(cars);
            }

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

