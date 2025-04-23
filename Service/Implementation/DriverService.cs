using AutoMapper;
using DTO;
using Service.Interface;
using DataAccessLayer.Repository;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class DriverService : IDriverService
    {
        private readonly IGenericRepository<DriverProfile> _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DriverService> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAddressService _addressService;


        public DriverService(IGenericRepository<DriverProfile> repository, IMapper mapper,
            IWebHostEnvironment webHostEnvironment, ILogger<DriverService> logger,
            AppDbContext context, UserManager<ApplicationUser> userManager, IAddressService addressService)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _addressService = addressService;
        }

        public async Task<DriverProfileDTO> AddDriver(DriverProfileDTO driver)
        {


            var driverEntity = _mapper.Map<DriverProfile>(driver);

            driverEntity.Id = Guid.NewGuid();

            var user = await _userManager.FindByIdAsync(driverEntity.UserId.ToString());
            if (user == null)
            {
                throw new Exception("User not found");
            }


            if (driver.Experience >= 50)
            {
                driverEntity.Experience = driver.Experience;
            }

            if (driver.ProfilePicture != null)
            {
                var profilePicturePath = await SaveFileAsync(driver.ProfilePicture, "uploads");
                user.ProfilePicture = profilePicturePath;
                await _userManager.UpdateAsync(user);
            }

            driverEntity.AadharCardFrontPhoto = driver.AadharCardFrontPhoto != null ? await SaveFileAsync(driver.AadharCardFrontPhoto, "uploads") : null;
            driverEntity.AadharCardBackPhoto = driver.AadharCardBackPhoto != null ? await SaveFileAsync(driver.AadharCardBackPhoto, "uploads") : null;
            driverEntity.LicenseFrontPhoto = driver.LicenseFrontPhoto != null ? await SaveFileAsync(driver.LicenseFrontPhoto, "uploads") : null;
            driverEntity.LicenseBackPhoto = driver.LicenseBackPhoto != null ? await SaveFileAsync(driver.LicenseBackPhoto, "uploads") : null;


            if (driver.Address != null)
            {
                var addressEntity = _mapper.Map<Address>(driver.Address);
                await _addressService.AddAsync(driver.Address);

            }

            var result = await _repository.AddAsync(driverEntity);
            await _context.SaveChangesAsync();

            driver.UserId = driverEntity.Id;
            return driver;
        }
        public async Task<bool> UpdateDriver(Guid Id, DriverProfileDTO driver)
        {
            try
            {
                var driverEntity = await _repository.GetByIdAsync(Id);
                if (driverEntity == null)
                {
                    _logger.LogError($"Driver with ID {Id} not found.");
                    throw new KeyNotFoundException("Driver not found.");
                }

                var user = await _userManager.FindByIdAsync(driverEntity.UserId.ToString());
                if (user == null)
                {
                    _logger.LogError($"User with ID {driverEntity.UserId} not found.");
                    throw new KeyNotFoundException("User not found.");
                }

                // Update Experience
                if (driver.Experience != null)
                    driverEntity.Experience = driver.Experience.Value;

                // Update ProfilePicture if provided
                if (driver.ProfilePicture != null)
                {
                    var profilePicturePath = await SaveFileAsync(driver.ProfilePicture, "uploads");
                    user.ProfilePicture = profilePicturePath;
                    await _userManager.UpdateAsync(user);
                }

                driverEntity.AadharCardFrontPhoto = driver.AadharCardFrontPhoto != null
                    ? await SaveFileAsync(driver.AadharCardFrontPhoto, "uploads")
                    : driverEntity.AadharCardFrontPhoto;

                driverEntity.AadharCardBackPhoto = driver.AadharCardBackPhoto != null
                    ? await SaveFileAsync(driver.AadharCardBackPhoto, "uploads")
                    : driverEntity.AadharCardBackPhoto;

                driverEntity.LicenseFrontPhoto = driver.LicenseFrontPhoto != null
                    ? await SaveFileAsync(driver.LicenseFrontPhoto, "uploads")
                    : driverEntity.LicenseFrontPhoto;

                driverEntity.LicenseBackPhoto = driver.LicenseBackPhoto != null
                    ? await SaveFileAsync(driver.LicenseBackPhoto, "uploads")
                    : driverEntity.LicenseBackPhoto;

                await _context.SaveChangesAsync();

                _logger.LogInformation($"Driver {Id} updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating driver with ID {Id}");
                return false;
            }
        }

            
        public async Task<string> SaveFileAsync(IFormFile file, string subFolder)
        {
            if (file == null || file.Length == 0) return null;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("Invalid file type. Only images are allowed.");

            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, subFolder);
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{subFolder}/{fileName}";
        }

        public async Task<IEnumerable<DriverProfileDTO>> GetAllAsync()
        {
            var drivers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverProfileDTO>>(drivers);
        }

        public async Task<DriverProfileDTO> GeyByIdAsync(Guid Id)
        {
            var driver = await _repository.GetByIdAsync(Id);
            if (driver == null) return null;
            return _mapper.Map<DriverProfileDTO>(driver);
        }
    }
}
