using System;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Http;

namespace Service.Interface
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverProfileDTO>> GetAllAsync();
        Task<DriverProfileDTO> AddDriver(DriverProfileDTO driver);
        Task<bool> UpdateDriver(Guid Id, DriverProfileDTO driver);
        Task<string> SaveFileAsync(IFormFile file, string subFolder);
        
    }
}
