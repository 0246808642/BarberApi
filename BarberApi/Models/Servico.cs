using BarberApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberApi.Models
{
    public class Servico
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public ServicosEnum NomeServico { get; set; }

        [MaxLength(300)]
        public string? Descricao { get; set; }

        [Required]
        public int DuracaoMin { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public double Preco { get; set; }
    }
}
