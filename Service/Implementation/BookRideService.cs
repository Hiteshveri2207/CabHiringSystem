using AutoMapper;
using DTO;
using DataAccessLayer.Entity;
using Service.Interface;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;

namespace Service.Implementation
{
    public class BookRideService : IBookRideService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookRideService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookRideDTO>> GetAllAsync()
        {
            var rides = await _context.BookRides.ToListAsync();
            return _mapper.Map<IEnumerable<BookRideDTO>>(rides);
        }

        public async Task<BookRideDTO> GetByIdAsync(Guid Id)
        {
            var ride = await _context.BookRides.FindAsync(Id);
            return ride == null ? null : _mapper.Map<BookRideDTO>(ride);
        }

        public async Task<BookRideDTO> AddAsync(BookRideDTO bookRideDTO)
        {
            try
            {


                var bookRide = _mapper.Map<BookRide>(bookRideDTO);
                bookRide.Id = Guid.NewGuid();

                await _context.BookRides.AddAsync(bookRide);
                await _context.SaveChangesAsync();

                return _mapper.Map<BookRideDTO>(bookRide);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookRideDTO> UpdateAsync(Guid Id, BookRideDTO bookRideDTO)
        {
            try
            {
                var existingRide = await _context.BookRides.FindAsync(Id);

                if (existingRide == null)
                {
                    throw new KeyNotFoundException($"Ride with ID {Id} not found.");
                }

                _mapper.Map(bookRideDTO, existingRide);

                _context.BookRides.Update(existingRide);
                await _context.SaveChangesAsync();

                return _mapper.Map<BookRideDTO>(existingRide);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var ride = await _context.BookRides.FindAsync(Id);
            if (ride == null) return false;

            _context.BookRides.Remove(ride);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
