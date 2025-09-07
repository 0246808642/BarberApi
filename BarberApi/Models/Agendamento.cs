using BarberApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberApi.Models
{
    public class Agendamento
    {
        [Key]
        public long AgendamentoId { get; set; }
        [Required]
        public DateTime DataHora { get; set; }

        [MaxLength(300)]
        public string Observacoes { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public long ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Cliente Cliente { get; set; }
        public virtual ICollection<Servico> Servicios { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
