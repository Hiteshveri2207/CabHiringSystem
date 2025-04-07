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
        Task<IEnumerable<BrandResponseDTO>> GetAllAsync();
    }
}
