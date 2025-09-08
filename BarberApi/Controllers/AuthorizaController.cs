using BarberApi.Data.Dtos.UserDto;
using BarberApi.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizaController : ControllerBase
    {
        private readonly IUser _userService; // Use a INTERFACE, não a classe direta

        public AuthorizaController(IUser userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterUserAsync(dto);
            return result;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.LoginUserAsync(dto);
            return result;
        }
    }
}
