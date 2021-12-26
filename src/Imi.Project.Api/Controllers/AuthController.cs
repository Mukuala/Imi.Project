using Imi.Project.Api.Core.Services.User;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMeService _meService;

        public AuthController(IMeService meService)
        {
            _meService = meService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto requestDto)
        {
            try
            {
                var result = await _meService.LoginAsync(requestDto);

                if (result.Succeeded)
                {
                    var responseDto = new LoginResponseDto { JwtToken = result.JwtToken };
                    return Ok(responseDto);

                }
                else
                {
                    return Unauthorized(result.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            try
            {
                var result = await _meService.RegisterAsync(registerRequestDto);

                if (result.Succeeded)
                {
                    return Ok("Thank you for your registration, you can now login");

                }
                else
                {
                    return BadRequest(result.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
                return BadRequest(ModelState);
            }
        }


    }
}
