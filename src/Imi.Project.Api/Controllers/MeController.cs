using Imi.Project.Api.Core.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class MeController : ControllerBase
    {
        private readonly IMeService _meService;

        public MeController(IMeService meService)
        {
            _meService = meService;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var profile = await _meService.GetCurrentUserProfileAsync();
            return Ok(profile);
        }


    }
}
