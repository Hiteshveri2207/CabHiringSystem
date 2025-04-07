using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Implementation;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/VehicleImage")]
    [ApiController]
    public class VehicleImageController : ControllerBase

    {
        private readonly IVehicleImageService _service;
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public VehicleImageController(IVehicleImageService service, IWebHostEnvironment environment, AppDbContext context)
        {
            _service = service;
            _environment = environment;
            _context = context;
        }

        [HttpPost("{vehicleId}/upload")]
        public async Task<ActionResult<bool>> UploadVehicleImageAsync(Guid vehicleId, IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Invalid image file.");
            }

            var uploadPath = Path.Combine(_environment.WebRootPath, "uploads".ToString());
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var relativePath = Path.Combine("uploads".ToString(), fileName);

            var vehicleImage = new VehicleImage
            {
                VehicleId = vehicleId,
                Image = relativePath
            };

            _context.VehicleImage.Add(vehicleImage);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Image uploaded successfully", imagePath = relativePath });
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<VehicleImageDTO>> GetById(Guid vehicleId)
        {
            var vehicleImage = await _service.GetById(vehicleId);

            if (vehicleImage == null)
            {
                return NotFound(new { message = "Vehicle image not found" });
            }

            return Ok(vehicleImage);
        }

    }
}

