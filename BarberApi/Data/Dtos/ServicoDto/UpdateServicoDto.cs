using BarberApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Data.Dtos.ServicoDto
{
    public class UpdateServicoDto
    {
        [Required(ErrorMessage = "Serviço é obrigatório")]
        [Range(1, 20, ErrorMessage = "Escolha um serviço válido.")]
        public ServicosEnum NomeServico { get; set; }

        [StringLength(300, ErrorMessage = "Observações não podem exceder {300} caracteres")]
        [Display(Name = "Observações")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Duração é obrigatória")]
        [Range(1, 300, ErrorMessage = "Duração deve ser entre 1 e 300 minutos")]
        public int DuracaoMin { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 10000.00, ErrorMessage = "Preço deve ser entre 0.01 e 10000.00")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
