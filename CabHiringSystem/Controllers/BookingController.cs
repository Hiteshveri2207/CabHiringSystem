using DataAccessLayer.Enum;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

    
       public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BookingResponseDTO>>> GetAllAsync()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("GetBy/{Id}")]
        public async Task<ActionResult<BookingResponseDTO>> GetByIdAsync(Guid Id)
        {
            var booking = await _bookingService.GetByIdAsync(Id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<BookingDTO>> AddAsync([FromBody] BookingDTO bookingDTO)
        {
            var result = await _bookingService.AddAsync(bookingDTO);

            if (result == null )
                return BadRequest("Booking creation failed.");

            return  result;
        }

        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<BookingDTO>> UpdateAsync(Guid Id, [FromBody] BookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _bookingService.UpdateAsync(Id, bookingDTO);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{Id}/Status")]
        public async Task<ActionResult<bool>> UpdateStatusAsync(Guid Id, [FromBody] BookingStatus bookingStatus)
        {
            var success = await _bookingService.UpdateStatusAsync(Id, bookingStatus);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid Id)
        {
            var success = await _bookingService.DeleteAsync(Id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

