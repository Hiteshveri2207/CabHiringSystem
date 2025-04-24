using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/BookRide")]
    [ApiController]
    public class BookRideController : ControllerBase
    {
            private readonly IBookRideService _bookRideService;

            public BookRideController(IBookRideService bookRideService)
            {
                _bookRideService = bookRideService;
            }


            [HttpGet("GetAll")]
            public async Task<ActionResult> GetAll()
            {
                var rides = await _bookRideService.GetAllAsync();
                return Ok(rides);
            }


            [HttpGet("GetBy/{Id}")]
            public async Task<ActionResult> GetById(Guid Id)
            {
                var ride = await _bookRideService.GetByIdAsync(Id);
                if (ride == null)
                    return NotFound();

                return Ok(ride);
            }


            [HttpPost("Add")]
            public async Task<ActionResult> Add([FromBody] BookRideDTO bookRideDTO)
            {
                var result = await _bookRideService.AddAsync(bookRideDTO);
                return Ok(result);
            }


            [HttpPut("UpdateBy/{Id}")]
            public async Task<ActionResult> Update(Guid Id, [FromBody] BookRideDTO bookRideDTO)
            {
                var result = await _bookRideService.UpdateAsync(Id, bookRideDTO);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }


            [HttpDelete("DeleteBy/{Id}")]
            public async Task<ActionResult> Delete(Guid Id)
            {
                var success = await _bookRideService.DeleteAsync(Id);
                if (!success)
                    return NotFound();

                return NoContent();
            }
        
    }
}
   