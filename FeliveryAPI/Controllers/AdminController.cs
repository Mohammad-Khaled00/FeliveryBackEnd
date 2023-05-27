using FeliveryAPI.Models;
using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminService AdminRepo { get; set; }
        public AdminController(IAdminService adminRepo)
        {
            AdminRepo = adminRepo;
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await AdminRepo.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }
    }
}
