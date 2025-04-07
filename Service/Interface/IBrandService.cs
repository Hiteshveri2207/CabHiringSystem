using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DTO;

namespace Service.Interface
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResponseDTO>> GetAllAsync();
        Task<IEnumerable<BrandDTO>> GetAllAsync();
        Task<BrandDTO> AddAsync(BrandDTO brandDTO);

        Task<bool> UpdateAsync(Guid Id, BrandDTO brandDTO);

        Task<bool> DeleteAsync(Guid Id);
        


    }
}
