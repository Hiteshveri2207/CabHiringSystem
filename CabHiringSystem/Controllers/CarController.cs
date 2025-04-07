using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<CarDTO>> AddCar([FromBody] CarDTO carDTO)
        {
            if (carDTO == null)
                return BadRequest("Car data is required");

            var createdCar = await _carService.AddCarAsync(carDTO);
            return Ok(createdCar); 
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<CarDTO>> UpdateCar(Guid Id, [FromBody] CarDTO carDTO)
        {
            if (carDTO == null)
                return BadRequest("Car data is required");

            var updatedCar = await _carService.UpdateCarAsync(Id, carDTO);
            if (updatedCar == null)
                return NotFound("Car not found");

            return Ok(updatedCar);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCar(Guid Id)
        {
            var isDeleted = await _carService.DeleteCarAsync(Id);
            if (!isDeleted)
                return NotFound("Car not found");

            return NoContent();
        }
    }
}
