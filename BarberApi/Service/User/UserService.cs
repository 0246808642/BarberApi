using BarberApi.Data.Dtos.UserDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarberApi.Service.User
{
    public class UserService : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IActionResult> RegisterUserAsync(RegisterUserDto dto)
        {
            // Verificar se usuário já existe
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return new BadRequestObjectResult("Usuário já existe");
            }

            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new BadRequestObjectResult($"Erro ao criar usuário: {errors}");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            return new OkObjectResult(GeraToken(dto.Email));
        }

        public async Task<IActionResult> LoginUserAsync(LoginUserDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return new BadRequestObjectResult("Email ou senha inválidos");
            }

            return new OkObjectResult(GeraToken(dto.Email));
        }

        private UserToken GeraToken(string email)
        {
            try
            {
                // Definir declarações do usuário
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, email),
                    new Claim("Barber", "UserBarber"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Gerar chave de acesso ao token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                // Gerar a assinatura digital do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Definir tempo de expiração do token
                var expireHours = _configuration.GetValue<int>("TokenConfiguration:ExpireHours");
                var expiration = DateTime.UtcNow.AddHours(expireHours);

                // Gerar o token
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["TokenConfiguration:Issuer"],
                    audience: _configuration["TokenConfiguration:Audience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds);

                return new UserToken()
                {
                    Authenticated = true,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration,
                    Message = "Token JWT OK"
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao gerar token: {ex.Message}");
            }
        }
    }
}
