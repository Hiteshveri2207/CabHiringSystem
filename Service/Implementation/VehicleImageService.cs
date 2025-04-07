using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Service.Interface;

namespace Service.Implementation
{
    public class VehicleImageService : IVehicleImageService
    {
        private readonly IGenericRepository<VehicleImage> _repository;
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public VehicleImageService(IGenericRepository<VehicleImage> repository, AppDbContext context, IWebHostEnvironment environment, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _environment = environment;
            _mapper = mapper;
        }
        public async Task<bool> UploadVehicleImageAsync(Guid vehicleId, IFormFile image)
        {
            if (image == null)
            {
                return false;
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

            var vehicleImage = new VehicleImage
            {
                VehicleId = vehicleId,
                Image = $"uploads"
            };

            _context.VehicleImage.Add(vehicleImage);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<VehicleImageDTO> GetById(Guid vehicleId)
        {
            var vehicleImage = await _context.VehicleImage.FindAsync(vehicleId);
            if (vehicleImage == null)
            {
                return null;
            }

            return _mapper.Map<VehicleImageDTO>(vehicleImage);
        }


    }

}





