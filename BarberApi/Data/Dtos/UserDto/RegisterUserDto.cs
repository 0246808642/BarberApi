using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.UserDto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "O campo Senha deve ter no mínimo 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmação de Senha é obrigatório")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
