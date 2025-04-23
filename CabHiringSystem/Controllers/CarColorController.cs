using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/CarColor")]
    [ApiController]
    public class CarColorController : ControllerBase
    {
       
     private readonly ICarColorService _carColorService;

        public CarColorController(ICarColorService carColorService)
        {
            _carColorService = carColorService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CarColorDTO>>> GetAllAsync()
        {
            var colors = await _carColorService.GetAllAsync();
            return Ok(colors);
        }

    }
}
