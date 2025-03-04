using AutoMapper;
using DTO;
using Service.Interface;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;

namespace Service.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly IGenericRepository<CustomerProfile> _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IGenericRepository<CustomerProfile> repository, UserManager<ApplicationUser> userManager, IMapper mapper, IWebHostEnvironment webHostEnvironment, ILogger<CustomerService> logger, AppDbContext context)

        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _userManager = userManager;
            _context = context;


        }





        public async Task<String> AddOrUpdate(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                return "Invalid Data";


            string profilePictureFileName = null;
            if (customerDTO.ProfilePicture != null)
            {
                profilePictureFileName = await UploadFileAsync(customerDTO.ProfilePicture);
            }



            var existingcustomer = await _repository.GetByIdAsync(customerDTO.Id);



            if (existingcustomer != null)
            {
                var userIdString = existingcustomer.UserId.ToString();
                var userINDb = await _userManager.FindByIdAsync(userIdString);
                userINDb.ProfilePicture = profilePictureFileName;
                await _userManager.UpdateAsync(userINDb);

                _mapper.Map(customerDTO, existingcustomer);
                await _repository.UpdateAsync(existingcustomer);


                return "Updated";
            }

            var newCustomerProfile = _mapper.Map<CustomerProfile>(customerDTO);
            newCustomerProfile.Id = Guid.NewGuid();

            await _repository.AddAsync(newCustomerProfile);
            var user = await _userManager.FindByIdAsync(customerDTO.UserId.ToString());
            user.ProfilePicture = profilePictureFileName;
            await _userManager.UpdateAsync(user);

            return "Created";
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded.");
            }

            try
            {
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }


                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                string fileUrl = $"/uploads/{uniqueFileName}";
                _logger.LogInformation($"File uploaded successfully: {fileUrl}");

                return fileUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError($"File upload failed: {ex.Message}");
                throw new Exception("File upload failed.", ex);
            }
        }


        public async Task<CustomerResponseDto> GetCustomerProfileByIdAsync(Guid id)
        {
            var customerQuery = _repository.GetQueryable(); // Get Customer IQueryable
            var userQuery = _userManager.Users.AsQueryable(); // Get ApplicationUser IQueryable
           

            var result = await (from customer in customerQuery
                                join user in userQuery on customer.UserId.ToString() equals user.Id
                                where customer.Id == id
                                select new CustomerResponseDto
                                {
                                    FirstName = user.FirstName,

                                    LastName = user.LastName,

                                    Email = user.Email,

                                    ProfilePictureUrl = user.ProfilePicture,

                                    PhoneNumber = user.PhoneNumber,

                                    RoleName = "Customer"



                                }).FirstOrDefaultAsync();

            return result;
        }

    }
}

