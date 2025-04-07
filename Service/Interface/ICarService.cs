
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Service.Interface
{
    public interface ICarService
    {
        Task<CarDTO> AddAsync(CarDTO carDTO);
        Task<IEnumerable<CarDTO>> GetAllAsync();
        Task<CarDTO> UpdateAsync(Guid Id, CarDTO carDTO);

        Task<bool> DeleteAsync(Guid Id);

    }
}
