using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using DTO;

namespace Service.Interface
{
    public interface IBookRideService
    {
        
        Task<IEnumerable<BookRideDTO>> GetAllAsync();
        Task<BookRideDTO> GetByIdAsync(Guid Id);
        Task<BookRideDTO> AddAsync(BookRideDTO bookRideDTO);
        Task<BookRideDTO>UpdateAsync(Guid Id, BookRideDTO bookRideDTO);
        Task<bool> DeleteAsync(Guid Id);
    }
}



    




