using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _repository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public BookingService(IGenericRepository<Booking> repository, IMapper mapper, AppDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<BookingResponseDTO>> GetAllAsync()
        {
            var bookings = await _context.Booking
           .Include(b => b.Customer)
           .ThenInclude(c => c.User)
           .ToListAsync();
            return _mapper.Map<IEnumerable<BookingResponseDTO>>(bookings);
        }
        public async Task<BookingResponseDTO> GetByIdAsync(Guid Id)
        {
            var booking = await _repository.GetByIdAsync(Id);
            if (booking == null) return null;
            return _mapper.Map<BookingResponseDTO>(booking);
        }

        public async Task<BookingDTO> AddAsync(BookingDTO bookingDTO)
        {
            var booking = _mapper.Map<Booking>(bookingDTO);
            booking.Id = Guid.NewGuid();

            var addedCar = await _repository.AddAsync(booking);

            return _mapper.Map<BookingDTO>(addedCar);

        }

        public async Task<BookingDTO> UpdateAsync(Guid Id, BookingDTO bookingDTO)
        {
            var booking = await _repository.GetByIdAsync(Id);
            if (booking == null) return null;

         
            _mapper.Map(bookingDTO, booking);

            await _repository.UpdateAsync(booking);

            return bookingDTO;
        }

        public async Task<bool> UpdateStatusAsync(Guid Id, BookingStatus bookingStatus)
        {
            var booking = await _repository.GetByIdAsync(Id);
            if (booking == null) return false;

            booking.Status = bookingStatus;
            await _repository.UpdateAsync(booking);
            return true;
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            var booking = await _repository.GetByIdAsync(Id);
            if (booking == null) return false;

            await _repository.DeleteAsync(Id);
            return true;
        }
    }
}
        