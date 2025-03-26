using DataAccessLayer.Entity;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interface;

namespace CabHiringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _service;
        public StateController(IStateService service)
        {
            _service = service;
            
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetAllAsync()
        {
            var states = await _service.GetAllAsync();
            return Ok(states);
        }
        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<StateDTO>> GetStateById(Guid Id)
        {
            var state = await _service.GetByIdAsync(Id);
            if (state == null)
            {
                return NotFound(new { Message = "State not found" });
            }
            return Ok(state);
        }
    }
}
