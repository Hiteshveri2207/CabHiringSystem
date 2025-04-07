using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BrandResponseDTO>>> GetAllAsync()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }
    }
}
