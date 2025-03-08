using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Http;

namespace Service.Interface
{
    public interface IVehicleImageService
    {
        Task<bool> UploadVehicleImageAsync(Guid vehicleId, IFormFile image);
      
    }
}
