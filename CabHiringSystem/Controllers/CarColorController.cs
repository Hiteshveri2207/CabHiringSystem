using System.Collections.Generic;
using System.Threading.Tasks;
using CabHiringSystem.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace CabHiringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarColorController : ControllerBase
    {
        private readonly ICarColorService _carColorService;

        public CarColorController(ICarColorService carColorService)
        {
            _carColorService = carColorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarColorDTO>>> GetAllColors()
        {
            var colors = await _carColorService.GetAllColorsAsync();
            return Ok(colors);
        }
    }
}
