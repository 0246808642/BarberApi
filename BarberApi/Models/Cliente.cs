using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberApi.Models
{
    public class Cliente
    {
        [Key]
        public long ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Telefone { get; set; }

        [Required]
        [MaxLength(245)]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
