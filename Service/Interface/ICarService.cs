
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
       
        Task<CarDTO> AddCarAsync(CarDTO carDTO);
        Task<CarDTO> UpdateCarAsync(Guid Id, CarDTO carDTO);
        Task<bool> DeleteCarAsync(Guid Id);
    }
}
