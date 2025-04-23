using DataAccessLayer.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CabHiringSystem.Controllers
{
    [Route("api/BookingStatus")]
    [ApiController]
    public class BookingStatusController : ControllerBase
    {
        [HttpGet("statuses")]
        public IActionResult GetStatuses()
        {
            var statuses = Enum.GetValues(typeof(BookingStatus))
                                .Cast<BookingStatus>()
                                .Select(s => new { Id = (int)s, StatusName = s.ToString() })
                                .ToList();

            return new ObjectResult(statuses) { StatusCode = 200 };
        }

    }
}
