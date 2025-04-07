﻿using DataAccessLayer.Entity;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _brandService.AddAsync(brandDTO);
            return result;

        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] BrandDTO brandDTO)
        {
            if (brandDTO == null)
                return BadRequest("Brand data is required.");

            var updated = await _brandService.UpdateAsync(id, brandDTO);
            if (!updated)
                return NotFound("Brand not found.");

            return NoContent(); 
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _brandService.DeleteAsync(id);
            if (!deleted)
                return NotFound("Brand not found.");

            return NoContent();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }
    }
}


       
    

