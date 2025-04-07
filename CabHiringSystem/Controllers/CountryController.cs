using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;

        }
        [HttpPost("Add")]
        public async Task<ActionResult<CountryDTO>> AddAsync(CountryDTO countryDTO)
        {
            await _countryService.AddAsync(countryDTO);
            return Ok(new { Message = "Country is  create", data = countryDTO });
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAllAsync()
        {
            var countries = await _countryService.GetAllAsync();
            return Ok(countries);
        }
    }
}

