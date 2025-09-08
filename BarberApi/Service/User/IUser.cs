using BarberApi.Data.Dtos.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Service.User
{
    public interface IUser
    {
        Task<IActionResult> RegisterUserAsync(RegisterUserDto dto);
        Task<IActionResult> LoginUserAsync(LoginUserDto dto);
    }
}
