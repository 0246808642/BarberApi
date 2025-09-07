using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.ClienteDto
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 150 caracteres")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Telefone deve ter entre 10 e 15 caracteres")]
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(245, ErrorMessage = "Email não pode exceder 245 caracteres")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
    }
}
