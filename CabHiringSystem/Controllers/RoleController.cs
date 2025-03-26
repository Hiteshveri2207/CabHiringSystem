using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CabHiringSystem.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet("GetAllRoles")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.Where(x => x.Name != "Admin").Select(r => new { r.Id, r.Name }).ToList();
            return Ok(roles);
        }
    }
}


