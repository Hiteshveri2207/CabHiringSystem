using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enum;
using DTO;

namespace Service.Interface
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingResponseDTO>> GetAllAsync();
        Task<BookingDTO> AddAsync(BookingDTO bookingDTO);
        Task<BookingDTO> UpdateAsync(Guid Id, BookingDTO bookingDTO);
        Task<bool> UpdateStatusAsync(Guid Id, BookingStatus bookingStatus );
        Task<bool> DeleteAsync(Guid Id);
        Task<BookingResponseDTO> GetByIdAsync(Guid Id);

    }
}
