using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.UserDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
