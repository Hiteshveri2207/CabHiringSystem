using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Service.Interface
{
    public interface IBrandService
    {
        Task<BrandDTO> AddAsync(BrandDTO brandDTO);

        Task<bool> UpdateAsync(Guid Id, BrandDTO brandDTO);

        Task<bool> DeleteAsync(Guid Id);
    }
}
